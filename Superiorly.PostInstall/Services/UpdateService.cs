// Copyright (c) 2026 Superiorly. MIT License — see LICENSE.
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.Json;
namespace Superiorly.PostInstall.Services;

public sealed record UpdateInfo(bool Available, string Version, string Url, string Sha256 = "", long Size = 0);

public interface IUpdateService
{
    Task<UpdateInfo> CheckForUpdatesAsync(CancellationToken token);
    Task<string?> DownloadAndStageAsync(UpdateInfo info, IProgress<int> progress, CancellationToken token);
}

public sealed class UpdateService : IUpdateService
{
    private static readonly HttpClient Http = new();
    // ponytail: public repo releases are the update channel (free, versioned); single x86 Setup asset.
    private const string ReleasesUrl = "https://api.github.com/repos/chiLL-Gekk0/Superiorly-Post-Install-FOR-SuperiorlyOS/releases/latest";
    private const string AssetPrefix = "Superiorly.PostInstall-Setup-";

    public async Task<UpdateInfo> CheckForUpdatesAsync(CancellationToken token)
    {
        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, ReleasesUrl);
            request.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue { NoCache = true };
            request.Headers.UserAgent.ParseAdd("Superiorly.PostInstall");
            using var response = await Http.SendAsync(request, token).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync(token).ConfigureAwait(false));
            var root = doc.RootElement;
            var version = root.TryGetProperty("tag_name", out var v) ? v.GetString() ?? "" : "";
            string url = "", sha = "";
            long size = 0;
            if (root.TryGetProperty("assets", out var assets) && assets.ValueKind == JsonValueKind.Array)
            {
                foreach (var a in assets.EnumerateArray())
                {
                    var name = a.TryGetProperty("name", out var nm) ? nm.GetString() ?? "" : "";
                    if (!name.StartsWith(AssetPrefix, StringComparison.OrdinalIgnoreCase) || !name.EndsWith(".exe", StringComparison.OrdinalIgnoreCase)) continue;
                    url = a.TryGetProperty("browser_download_url", out var du) ? du.GetString() ?? "" : "";
                    var digest = a.TryGetProperty("digest", out var dg) ? dg.GetString() ?? "" : "";
                    if (digest.StartsWith("sha256:", StringComparison.OrdinalIgnoreCase)) digest = digest[7..];
                    if (digest.Length == 64) sha = digest;
                    if (a.TryGetProperty("size", out var sz) && sz.TryGetInt64(out var n)) size = n;
                    break;
                }
            }
            var current = Assembly.GetExecutingAssembly().GetName().Version;
            var latest = ParseVersion(version);
            if (latest == null || current == null || string.IsNullOrEmpty(version) || string.IsNullOrEmpty(url))
                return new UpdateInfo(false, "", "");
            if (Normalize(current).CompareTo(Normalize(latest)) >= 0)
                return new UpdateInfo(false, version, url, sha, size);
            return new UpdateInfo(true, version, url, sha, size);
        }
        catch { return new UpdateInfo(false, "", ""); }
    }

    public async Task<string?> DownloadAndStageAsync(UpdateInfo info, IProgress<int> progress, CancellationToken token)
    {
        try
        {
            if (string.IsNullOrEmpty(info.Url)) return null;
            var stage = Path.Combine(Path.GetTempPath(), "Superiorly.Update", info.Version);
            Directory.CreateDirectory(stage);
            var appStage = Path.Combine(stage, "app");
            if (Directory.Exists(appStage)) Directory.Delete(appStage, true);
            var zip = Path.Combine(stage, "setup.exe");
            using var request = new HttpRequestMessage(HttpMethod.Get, info.Url);
            request.Headers.UserAgent.ParseAdd("Superiorly.PostInstall");
            using var response = await Http.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, token).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var total = response.Content.Headers.ContentLength ?? info.Size;
            using var net = await response.Content.ReadAsStreamAsync(token).ConfigureAwait(false);
            using var fs = File.Create(zip);
            var buf = new byte[81920];
            long done = 0;
            int read;
            while ((read = await net.ReadAsync(buf, token).ConfigureAwait(false)) > 0)
            {
                await fs.WriteAsync(buf.AsMemory(0, read), token).ConfigureAwait(false);
                done += read;
                if (total > 0) progress.Report((int)Math.Clamp(done * 100 / total, 0, 100));
            }
            if (!string.IsNullOrEmpty(info.Sha256))
            {
                fs.Close();
                using var sha = SHA256.Create();
                using var check = File.OpenRead(zip);
                var hash = Convert.ToHexString(await Task.Run(() => sha.ComputeHash(check), token).ConfigureAwait(false));
                if (!hash.Equals(info.Sha256, StringComparison.OrdinalIgnoreCase)) { try { File.Delete(zip); } catch { } return null; }
            }
            progress.Report(100);
            return zip;
        }
        catch { return null; }
    }

    private static Version Normalize(Version v) =>
        new(Math.Max(v.Major, 0), Math.Max(v.Minor, 0), Math.Max(v.Build, 0), Math.Max(v.Revision, 0));

    private static Version? ParseVersion(string tag)
    {
        var t = tag.Trim();
        if (t.StartsWith("v", StringComparison.OrdinalIgnoreCase)) t = t[1..];
        while (t.Split('.').Length < 4) t += ".0";
        return Version.TryParse(t, out var v) ? Normalize(v) : null;
    }
}
