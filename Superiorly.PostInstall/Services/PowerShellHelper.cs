namespace Superiorly.PostInstall.Services;

using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

internal static class PowerShellHelper
{
    private static readonly Regex WingetIdRx = new(@"winget\s+install\s+--id\s+([^\s""']+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public static bool PreferOs64View => Environment.Is64BitOperatingSystem && !Environment.Is64BitProcess;

    public static string ExePath { get; } = ResolveExePath();

    private static string ResolveExePath()
    {
        // sysnative reaches 64-bit system32 from a 32-bit process
        if (PreferOs64View)
        {
            var sysnative = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Sysnative", "WindowsPowerShell", "v1.0", "powershell.exe");
            if (File.Exists(sysnative)) return sysnative;
        }
        return "powershell.exe";
    }

    public static string ExtractScript(string command)
    {
        var s = command;
        s = StripPrefix(s, "powershell");
        s = StripPrefix(s, "-NoProfile");
        s = StripPrefix(s, "-ExecutionPolicy");
        s = StripPrefix(s, "Bypass");
        s = StripPrefix(s, "-Command");
        s = StripPrefix(s, "-File");
        return s.Trim();
    }

    public static bool IsSuccessExitCode(int code) =>
        code == 0 || code == 3010 || code == 1641 ||
        code == -1978335189 || code == -1978335188 || code == -1978335212;

    public static bool IsPsScript(string command)
    {
        var t = command.TrimStart();
        return t.StartsWith("powershell", StringComparison.OrdinalIgnoreCase)
            || t.Contains("$env:TEMP", StringComparison.OrdinalIgnoreCase)
            || t.Contains("$env:LOCALAPPDATA", StringComparison.OrdinalIgnoreCase)
            || t.Contains("$env:ProgramData", StringComparison.OrdinalIgnoreCase)
            || t.Contains("DownloadFile", StringComparison.OrdinalIgnoreCase)
            || t.Contains("Expand-Archive", StringComparison.OrdinalIgnoreCase)
            || t.StartsWith("$d", StringComparison.OrdinalIgnoreCase)
            || t.StartsWith("$e", StringComparison.OrdinalIgnoreCase);
    }

    public static bool TryChocoFallback(string script)
    {
        var m = WingetIdRx.Match(script);
        if (!m.Success) return false;
        var wingetId = m.Groups[1].Value.Trim('"', '\'');
        var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["Google.Chrome"] = "googlechrome",
            ["Mozilla.Firefox"] = "firefox",
            ["Brave.Brave"] = "brave",
            ["Vivaldi.Vivaldi"] = "vivaldi",
            ["Opera.Opera"] = "opera",
            ["Opera.OperaGX"] = "opera-gx",
            ["Microsoft.Edge"] = "microsoft-edge",
            ["TorProject.TorBrowser"] = "tor-browser",
            ["Hibbiki.Chromium"] = "chromium",
            ["Waterfox.Waterfox"] = "waterfox",
            ["Yandex.Browser"] = "yandex",
            ["MoonchildProductions.PaleMoon"] = "palemoon",
            ["MullvadVPN.MullvadBrowser"] = "mullvad-browser",
            ["KDE.Falkon"] = "falkon",
            ["Ablaze.Floorp"] = "floorp",
            ["Zen-Team.Zen-Browser"] = "zen-browser",
            ["TheBrowserCompany.Arc"] = "arc",
            ["LibreWolf.LibreWolf"] = "librewolf",
            ["Alex313031.Thorium.AVX2"] = "thorium",
            ["eloston.ungoogled-chromium"] = "ungoogled-chromium",
            ["HiddenReflex.EpicBrowser"] = "epic-browser",
            ["Microsoft.Sysinternals.ProcessExplorer"] = "sysinternals",
            ["Microsoft.Sysinternals.Autoruns"] = "sysinternals",
            ["TechPowerUp.NVCleanstall"] = "nvcleanstall",
            ["Orbmu2k.NvidiaInspector"] = "nvidia-inspector",
            ["Logitech.OnboardMemoryManager"] = "logitech-omm",
        };
        string chocoId;
        if (!map.TryGetValue(wingetId, out chocoId!))
        {
            var parts = wingetId.Split('.');
            chocoId = parts[^1].ToLowerInvariant();
        }
        foreach (var candidate in new[] { chocoId, wingetId.Replace('.', '-').ToLowerInvariant() })
        {
            try
            {
                var psi = new ProcessStartInfo("choco", $"install {candidate} -y --no-progress --acceptlicense")
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = AppContext.BaseDirectory
                };
                using var p = Process.Start(psi);
                if (p == null) continue;
                p.WaitForExit(300000);
                if (p.ExitCode == 0 || p.ExitCode == 3010 || p.ExitCode == 1641) return true;
            }
            catch { }
        }
        return false;
    }

    // these fail benignly; state verified afterwards via check
    public static bool IsBestEffortCommand(string command)
    {
        var t = command.TrimStart();
        return t.StartsWith("sc.exe ", StringComparison.OrdinalIgnoreCase)
            || t.StartsWith("taskkill", StringComparison.OrdinalIgnoreCase)
            || t.Contains("reg.exe delete", StringComparison.OrdinalIgnoreCase)
            || t.Contains("reg delete", StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsLongRunning(IEnumerable<string> commands)
    {
        foreach (var c in commands)
        {
            var t = c.TrimStart();
            if (t.StartsWith("choco ", StringComparison.OrdinalIgnoreCase)) return true;
            if (t.StartsWith("winget ", StringComparison.OrdinalIgnoreCase)) return true;
            if (t.Contains("DownloadFile", StringComparison.OrdinalIgnoreCase)) return true;
            if (t.Contains("Invoke-WebRequest", StringComparison.OrdinalIgnoreCase)) return true;
            if (t.Contains("Expand-Archive", StringComparison.OrdinalIgnoreCase)) return true;
            if (t.Contains("Start-BitsTransfer", StringComparison.OrdinalIgnoreCase)) return true;
            // dism takes minutes, sc.exe batches seconds; both need progress
            if (t.StartsWith("dism ", StringComparison.OrdinalIgnoreCase)) return true;
            if (t.StartsWith("sc.exe ", StringComparison.OrdinalIgnoreCase)) return true;
        }
        return false;
    }

    public static bool IsAlreadyCached(IEnumerable<string> commands)
    {
        foreach (var c in commands)
        {
            var targets = ExtractTargetPaths(c);
            if (targets.Count == 0) return false;
            foreach (var t in targets)
                if (!File.Exists(t)) return false;
        }
        return true;
    }

    private static List<string> ExtractTargetPaths(string command)
    {
        var paths = new List<string>();
        var tempDir = System.Text.RegularExpressions.Regex.Match(
            command, @"\$(\w+)\s*=\s*\$env:TEMP\s*\+\s*'(?:\\)?([^']+)'",
            System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        var dir = tempDir.Success
            ? Path.Combine(Path.GetTempPath(), tempDir.Groups[2].Value.TrimStart('\\'))
            : Path.GetTempPath();

        foreach (System.Text.RegularExpressions.Match m in
                 System.Text.RegularExpressions.Regex.Matches(
                     command, @"DownloadFile\(\s*'([^']+?)'\s*,\s*\$(\w+)\s*\)",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase))
        {
            var fileName = Path.GetFileName(new Uri(m.Groups[1].Value).LocalPath);
            if (!string.IsNullOrEmpty(fileName)) paths.Add(Path.Combine(dir, fileName));
        }

        foreach (System.Text.RegularExpressions.Match m in
                 System.Text.RegularExpressions.Regex.Matches(
                     command, @"DownloadFile\(\s*'([^']+?)'\s*,\s*\$\w+\s*\+\s*'([^']*?)'\s*\)",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase))
        {
            var fileName = Path.GetFileName(new Uri(m.Groups[1].Value).LocalPath);
            if (!string.IsNullOrEmpty(fileName)) paths.Add(Path.Combine(dir, fileName));
        }

        foreach (System.Text.RegularExpressions.Match m in
                 System.Text.RegularExpressions.Regex.Matches(
                     command, @"\$(\w+)\s*=\s*\$(\w+)\s*\+\s*'(?:\\)?([^']+\.(?:exe|zip|msi))'",
                     System.Text.RegularExpressions.RegexOptions.IgnoreCase))
        {
            paths.Add(Path.Combine(dir, m.Groups[3].Value.TrimStart('\\')));
        }
        return paths;
    }

    private static string StripPrefix(string s, string prefix)
    {
        if (s.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
        {
            s = s[prefix.Length..];
            var i = 0;
            while (i < s.Length && (s[i] == ' ' || s[i] == '\t')) i++;
            s = s[i..];
        }
        return s;
    }
}
