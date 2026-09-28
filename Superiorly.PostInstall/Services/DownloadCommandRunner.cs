using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Superiorly.PostInstall.Services;

public interface IDownloadCommandRunner
{
    Task<bool> RunAllAsync(IEnumerable<string> commands, IProgress<int>? progress = null, CancellationToken ct = default, bool fastAnimate = false);
}

public sealed class DownloadCommandRunner : IDownloadCommandRunner
{
    // matches the WebClient.DownloadFile('url','dest') calls our tool scripts generate
    private static readonly Regex DownloadRx = new(@"\(New-Object Net\.WebClient\)\.DownloadFile\('(?<url>[^']+)','(?<dest>[^']+)'\)", RegexOptions.Compiled);
    private static readonly HttpClient Http = new() { Timeout = TimeSpan.FromMinutes(10) };

    // ponytail: some hosts block bot-like UAs (Python-urllib -> 403); identify or die
    static DownloadCommandRunner() => Http.DefaultRequestHeaders.UserAgent.ParseAdd("Superiorly.PostInstall");

    public async Task<bool> RunAllAsync(IEnumerable<string> commands, IProgress<int>? progress = null, CancellationToken ct = default, bool fastAnimate = false)
    {
        var allOk = true;
        var cmdList = commands.ToList();

        for (var i = 0; i < cmdList.Count; i++)
        {
            var trimmed = cmdList[i].TrimStart();
            var isPsScript = PowerShellHelper.IsPsScript(trimmed);
            var bestEffort = PowerShellHelper.IsBestEffortCommand(cmdList[i]);

            if (isPsScript)
            {
                var script = trimmed.StartsWith("powershell", StringComparison.OrdinalIgnoreCase)
                    ? PowerShellHelper.ExtractScript(trimmed) : trimmed;

                // real byte-level download progress; rewrites the script to copy the pre-downloaded file
                var realDownload = await PreDownloadAsync(script, progress, ct);
                if (realDownload.downloaded) script = realDownload.script;
                var ps1 = Path.Combine(Path.GetTempPath(), $"si_{Guid.NewGuid():N}.ps1");
                File.WriteAllText(ps1, script);

                var info = new ProcessStartInfo
                {
                    FileName = PowerShellHelper.ExePath,
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -File \"{ps1}\"",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = AppContext.BaseDirectory
                };

                using var process = Process.Start(info);
                if (process == null) { allOk = false; continue; }

                var pctPerStep = 100.0 / cmdList.Count;
                var startPct = (int)(i * pctPerStep);
                var endPct = (int)((i + 1) * pctPerStep);
                if (!realDownload.downloaded) progress?.Report(startPct + 1);

                var animCts = new CancellationTokenSource();
                var animTask = realDownload.downloaded
                    ? Task.CompletedTask
                    : AnimateProgressAsync(progress, startPct + 1, endPct - 1, animCts.Token, fastAnimate ? 60 : 180);

                try { await process.WaitForExitAsync(ct); }
                finally { animCts.Cancel(); try { await animTask; } catch { } animCts.Dispose(); }

                if (!bestEffort && !PowerShellHelper.IsSuccessExitCode(process.ExitCode))
                {
                    if (script.Contains("winget install", StringComparison.OrdinalIgnoreCase) && PowerShellHelper.TryChocoFallback(script)) { }
                    else allOk = false;
                }
                progress?.Report(endPct);

                try { File.Delete(ps1); } catch { }
                if (realDownload.tempPath != null) { try { File.Delete(realDownload.tempPath); } catch { } }
            }
            else
            {
                var info = new ProcessStartInfo
                {
                    FileName = PowerShellHelper.ExePath,
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{cmdList[i].Replace("\"", "\\\"")}\"",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = AppContext.BaseDirectory
                };

                using var process = Process.Start(info);
                if (process == null) { allOk = false; continue; }

                var pctPerStep = 100.0 / cmdList.Count;
                var startPct = (int)(i * pctPerStep);
                var endPct = (int)((i + 1) * pctPerStep);
                progress?.Report(startPct + 1);
                var animCts = new CancellationTokenSource();
                var animTask = AnimateProgressAsync(progress, startPct + 1, endPct - 1, animCts.Token, fastAnimate ? 60 : 180);
                try { await process.WaitForExitAsync(ct); }
                finally { animCts.Cancel(); try { await animTask; } catch { } animCts.Dispose(); }
                if (!bestEffort && !PowerShellHelper.IsSuccessExitCode(process.ExitCode))
                {
                    if (cmdList[i].Contains("winget install", StringComparison.OrdinalIgnoreCase) && PowerShellHelper.TryChocoFallback(cmdList[i])) { }
                    else allOk = false;
                }
                progress?.Report(endPct);
            }
        }

        progress?.Report(100);
        return allOk;
    }

    // downloads the script's file with HttpClient and reports true byte progress;
    // on any failure returns the script untouched so PowerShell does the download as before
    private static async Task<(bool downloaded, string script, string? tempPath)> PreDownloadAsync(string script, IProgress<int>? progress, CancellationToken ct)
    {
        var m = DownloadRx.Match(script);
        if (!m.Success) return (false, script, null);
        try
        {
            using var resp = await Http.GetAsync(m.Groups["url"].Value, HttpCompletionOption.ResponseHeadersRead, ct);
            resp.EnsureSuccessStatusCode();
            var total = resp.Content.Headers.ContentLength ?? -1;
            var tmp = Path.Combine(Path.GetTempPath(), $"si_dl_{Guid.NewGuid():N}.part");
            await using var fs = File.Create(tmp);
            await using var src = await resp.Content.ReadAsStreamAsync(ct);
            var buf = new byte[81920];
            long read = 0;
            int n;
            while ((n = await src.ReadAsync(buf, ct)) > 0)
            {
                await fs.WriteAsync(buf.AsMemory(0, n), ct);
                read += n;
                if (total > 0) progress?.Report((int)Math.Min(99, read * 100 / total));
            }
            progress?.Report(100);
            var dest = m.Groups["dest"].Value;
            // single-quoted PS string: escape embedded quotes
            if (dest.Contains('\'')) return (false, script, null);
            return (true, script.Replace(m.Value, $"Copy-Item '{tmp}' '{dest}' -Force"), tmp);
        }
        catch
        {
            return (false, script, null);
        }
    }

    private static async Task AnimateProgressAsync(IProgress<int>? progress, int from, int to, CancellationToken ct, int stepMs = 180)
    {
        if (progress == null || from >= to) return;
        var cur = from;
        try
        {
            while (cur < to && !ct.IsCancellationRequested)
            {
                await Task.Delay(stepMs, ct);
                cur = Math.Min(to, cur + 1);
                progress.Report(cur);
            }
        }
        catch (OperationCanceledException) { }
    }
}
