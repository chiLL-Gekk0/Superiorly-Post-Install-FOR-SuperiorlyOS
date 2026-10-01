using System.Diagnostics;
using System.IO;

namespace Superiorly.PostInstall.Services;

public interface IDownloadCommandRunner
{
    Task<bool> RunAllAsync(IEnumerable<string> commands, IProgress<int>? progress = null, CancellationToken ct = default, bool fastAnimate = false);
}

public sealed class DownloadCommandRunner : IDownloadCommandRunner
{
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
                progress?.Report(startPct + 1);

                var animCts = new CancellationTokenSource();
                var animTask = AnimateProgressAsync(progress, startPct + 1, endPct - 1, animCts.Token, fastAnimate ? 60 : 180);

                try { await process.WaitForExitAsync(ct); }
                finally { animCts.Cancel(); try { await animTask; } catch { } animCts.Dispose(); }

                if (!bestEffort && !PowerShellHelper.IsSuccessExitCode(process.ExitCode))
                {
                    if (script.Contains("winget install", StringComparison.OrdinalIgnoreCase) && PowerShellHelper.TryChocoFallback(script)) { }
                    else allOk = false;
                }
                progress?.Report(endPct);

                try { File.Delete(ps1); } catch { }
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
