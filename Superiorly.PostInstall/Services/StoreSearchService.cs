using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Superiorly.PostInstall.Services;

public sealed record StoreHit(string Name, string PackageId, string Publisher, string Source);

public interface IStoreSearchService
{
    Task<IReadOnlyList<StoreHit>> SearchAsync(string query, IProgress<StoreHit>? progress, CancellationToken token);
}

public sealed class StoreSearchService : IStoreSearchService
{
    private static readonly HttpClient Http = new() { Timeout = TimeSpan.FromSeconds(12) };
    private static readonly Regex ValidId = new("^[A-Za-z0-9._-]+$", RegexOptions.Compiled | RegexOptions.CultureInvariant);
    private static readonly TimeSpan WingetTimeout = TimeSpan.FromSeconds(15);
    private static readonly string[] BlockedPhrases =
    [
        "codes tips", "mod manager", "offline", "(prc)", " guide", "quiz", "wallpaper", "tips offline",
    ];

    public async Task<IReadOnlyList<StoreHit>> SearchAsync(string query, IProgress<StoreHit>? progress, CancellationToken token)
    {
        var q = query.Trim();
        if (q.Length == 0) return [];
        // ponytail: ONE winget spawn (all sources) + store API in parallel; stream each leg as it
        // finishes so first results paint in ~1-3s; soft cap ~8s then merge partials (rival tradeoff).
        using var softCts = CancellationTokenSource.CreateLinkedTokenSource(token);
        var storeTask = QueryStoreApiAsync(q, softCts.Token);
        var wingetTask = Task.Run(() => QueryWinget(q, null, softCts.Token), softCts.Token);
        var pending = new Dictionary<Task<List<StoreHit>>, bool> { [storeTask] = true, [wingetTask] = false };
        var storeAccum = new List<StoreHit>();
        var wingetAccum = new List<StoreHit>();
        var reportedIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var deadline = Task.Delay(TimeSpan.FromSeconds(8), token);
        while (pending.Count > 0)
        {
            var waiting = pending.Keys.Cast<Task>().Append(deadline).ToList();
            var done = await Task.WhenAny(waiting).ConfigureAwait(false);
            if (ReferenceEquals(done, deadline) || token.IsCancellationRequested) break;
            var leg = (Task<List<StoreHit>>)done;
            if (!pending.TryGetValue(leg, out var isStore)) continue;
            pending.Remove(leg);
            List<StoreHit> list;
            try { list = await leg.ConfigureAwait(false); } catch { continue; }
            (isStore ? storeAccum : wingetAccum).AddRange(list);
            if (progress != null)
                foreach (var h in Merge(storeAccum, wingetAccum, q))
                    if (reportedIds.Add(h.PackageId)) progress.Report(h);
        }
        try { softCts.Cancel(); } catch { }
        List<StoreHit> final;
        if (storeAccum.Count == 0 && wingetAccum.Count == 0)
        {
            // ponytail: both legs failed/empty — msstore-only retry is a rare last resort
            var ms = await Task.Run(() => QueryWinget(q, "msstore", token), token).ConfigureAwait(false);
            final = Merge([], ms, q).ToList();
        }
        else final = Merge(storeAccum, wingetAccum, q).ToList();
        return final;
    }

    public static void Warmup()
    {
        try { _ = Task.Run(() => { try { QueryWinget("test", "winget", CancellationToken.None); } catch { } }); } catch { }
    }

    private static async Task<List<StoreHit>> QueryStoreApiAsync(string query, CancellationToken token)
    {
        var hits = new List<StoreHit>();
        try
        {
            // ponytail: v9.0 pages = same backend as the winget msstore source; official listings first.
            // Cards carry Title+ProductId adjacent; trailers without ProductId are skipped by Accept.
            var url = $"https://storeedgefd.dsx.mp.microsoft.com/v9.0/pages/searchResults?market=US&locale=en-US&deviceFamily=windows.desktop&query={Uri.EscapeDataString(query)}";
            using var response = await Http.GetAsync(url, token).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync(token).ConfigureAwait(false));
            if (doc.RootElement.ValueKind != JsonValueKind.Array) return hits;
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var item in doc.RootElement.EnumerateArray())
            {
                if (!item.TryGetProperty("Payload", out var payload)) continue;
                if (!payload.TryGetProperty("SearchResults", out var cards)) continue;
                if (cards.ValueKind != JsonValueKind.Array) continue;
                foreach (var card in cards.EnumerateArray())
                {
                    var name = card.TryGetProperty("Title", out var t) ? t.GetString() ?? "" : "";
                    var id = card.TryGetProperty("ProductId", out var p) ? p.GetString() ?? "" : "";
                    var pub = card.TryGetProperty("PublisherName", out var pb) ? pb.GetString() ?? "" : "";
                    if (!Accept(name, id, query)) continue;
                    if (!seen.Add(id)) continue;
                    hits.Add(new StoreHit(name, id, pub, "msstore"));
                }
            }
        }
        catch { }
        return hits;
    }

    private static List<StoreHit> QueryWinget(string query, string? source, CancellationToken token)
    {
        var hits = new List<StoreHit>();
        try
        {
            var src = source == null ? "" : $" -s {source}";
            using var process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "winget",
                Arguments = $"search --query \"{query.Replace("\"", "")}\" --accept-source-agreements --disable-interactivity{src}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
            };
            var stdout = new StringBuilder();
            process.OutputDataReceived += (_, e) => { if (e.Data != null) stdout.AppendLine(e.Data); };
            process.ErrorDataReceived += (_, e) => { };
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            using var timeoutCts = new CancellationTokenSource(WingetTimeout);
            using var linked = CancellationTokenSource.CreateLinkedTokenSource(token, timeoutCts.Token);
            try { process.WaitForExitAsync(linked.Token).GetAwaiter().GetResult(); }
            catch (OperationCanceledException) { try { process.Kill(); } catch { } return hits; }
            if (process.ExitCode != 0) return hits;
            foreach (var line in stdout.ToString().Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries))
            {
                if (token.IsCancellationRequested) break;
                var trimmed = line.Trim();
                if (trimmed.StartsWith("Name", StringComparison.OrdinalIgnoreCase)) continue;
                if (trimmed.StartsWith("---")) continue;
                var cols = Regex.Split(trimmed, @"\s{2,}");
                if (cols.Length < 2) continue;
                var name = cols[0].Trim().TrimEnd('…', '.');
                var id = cols[1].Trim();
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(id) || id.Contains(' ')) continue;
                if (!Accept(name, id, query)) continue;
                var rowSource = source ?? (cols[^1].Trim().Equals("msstore", StringComparison.OrdinalIgnoreCase) ? "msstore" : "winget");
                hits.Add(new StoreHit(name, id, "", rowSource));
            }
        }
        catch { }
        return hits;
    }

    private static IReadOnlyList<StoreHit> Merge(List<StoreHit> store, List<StoreHit> winget, string query)
    {
        var byName = new Dictionary<string, StoreHit>(StringComparer.OrdinalIgnoreCase);
        var seenIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var hit in store)
        {
            if (!seenIds.Add(hit.PackageId)) continue;
            byName.TryAdd(Normalize(hit.Name), hit);
        }
        foreach (var hit in winget)
        {
            // ponytail: Store Downloader lists Store catalog only (winget-source rows belong to winget, not the Store)
            if (!string.Equals(hit.Source, "msstore", StringComparison.OrdinalIgnoreCase)) continue;
            var key = Normalize(hit.Name);
            if (byName.TryGetValue(key, out var existing))
            {
                if (existing.Publisher.Length == 0 && hit.Publisher.Length > 0 && seenIds.Add(hit.PackageId))
                {
                    seenIds.Remove(existing.PackageId);
                    byName[key] = hit;
                }
                continue;
            }
            if (!seenIds.Add(hit.PackageId)) continue;
            byName[key] = hit;
        }
        return byName.Values
            .OrderBy(h => Rank(h.Name, query))
            .ThenBy(h => h.Name, StringComparer.OrdinalIgnoreCase)
            .Take(25)
            .ToList();
    }

    internal static bool Accept(string name, string id, string query)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(id)) return false;
        if (!ValidId.IsMatch(id)) return false;
        if (name.Contains('\\')) return false;
        if (!name.Any(char.IsLetterOrDigit)) return false;
        if (!name.Contains(query, StringComparison.OrdinalIgnoreCase)) return false;
        var lowered = name.ToLowerInvariant();
        foreach (var phrase in BlockedPhrases)
            if (lowered.Contains(phrase)) return false;
        return true;
    }

    private static int Rank(string name, string query)
    {
        var n = name.Trim();
        if (n.Equals(query, StringComparison.OrdinalIgnoreCase)) return 0;
        if (n.StartsWith(query, StringComparison.OrdinalIgnoreCase)) return 1;
        if (n.Split(' ').Any(w => w.StartsWith(query, StringComparison.OrdinalIgnoreCase))) return 2;
        return 3;
    }

    private static string Normalize(string name)
    {
        var chars = name.Where(char.IsLetterOrDigit).ToArray();
        return new string(chars).ToLowerInvariant();
    }
}
