using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

public partial class CardViewModel : ObservableObject {

    public void RefreshState()
    {
        if (_checks.Count == 0) return;
        IsChecking = true;
        var checks = _checks.ToList();
        Task.Run(async () =>
        {
            await _stateSemaphore.WaitAsync();
            try
            {
                bool on;
                if (TryFastCheck(checks, out var fast)) on = fast;
                else on = false;
                System.Windows.Application.Current.Dispatcher.InvokeAsync(() => { IsOn = on; IsChecking = false; });
            }
            catch
            {
                System.Windows.Application.Current.Dispatcher.InvokeAsync(() => IsChecking = false);
            }
            finally { _stateSemaphore.Release(); }
        });
    }

    private async Task RefreshStateAsync()
    {
        if (_checks.Count == 0) return;
        bool on;
        if (TryFastCheck(_checks, out var fast)) on = fast;
        else on = await Task.Run(() => false);
        IsOn = on;
    }

    private static bool TryFastCheck(IReadOnlyList<string> checks, out bool result)
    {
        var negate = checks.Count > 0 && checks[0].TrimStart().StartsWith("!", StringComparison.Ordinal);
        var list = negate
            ? checks.Select(c => { var t = c.TrimStart(); return t.StartsWith("!", StringComparison.Ordinal) ? t[1..].TrimStart() : c; }).ToList()
            : checks;
        if (!TryFastCheckInner(list, out result)) return false;
        if (negate) result = !result;
        return true;
    }

    private static bool TryFastCheckInner(IReadOnlyList<string> checks, out bool result)
    {
        result = false;
        try
        {
            foreach (var c in checks)
            {
                if (c.StartsWith("file:", StringComparison.OrdinalIgnoreCase))
                {
                    var pattern = ExpandOsPaths(c[5..].Trim());
                    if (pattern.IndexOf('*') < 0)
                    {
                        result = File.Exists(pattern);
                        return true;
                    }
                    var lower = pattern.ToLowerInvariant();
                    if (lower.Contains(@"\program files") || lower.Contains(@"\programdata") || lower.Contains(@"\windows\"))
                    {
                        result = false;
                        return true;
                    }
                    try
                    {
                        var fileName = Path.GetFileName(pattern);
                        if (string.IsNullOrEmpty(fileName) || fileName.Contains('*'))
                            fileName = "*";
                        var rootPart = pattern.Contains("**", StringComparison.Ordinal)
                            ? pattern[..pattern.IndexOf("**", StringComparison.Ordinal)].TrimEnd('\\', '/')
                            : Path.GetDirectoryName(pattern[..pattern.IndexOf('*')]) ?? "";
                        rootPart = ExpandOsPaths(rootPart);
                        if (string.IsNullOrEmpty(rootPart) || !Directory.Exists(rootPart)) { result = false; return true; }
                        result = Directory.EnumerateFiles(rootPart, fileName, SearchOption.TopDirectoryOnly).Any();
                        if (!result && Directory.EnumerateDirectories(rootPart).Any())
                            result = Directory.EnumerateFiles(rootPart, fileName, SearchOption.AllDirectories).Any();
                    }
                    catch { result = false; }
                    return true;
                }
                if (c.IndexOf("reg", StringComparison.OrdinalIgnoreCase) >= 0 && c.IndexOf("query", StringComparison.OrdinalIgnoreCase) >= 0 && c.Contains("/v", StringComparison.OrdinalIgnoreCase))
                {
                    var m = System.Text.RegularExpressions.Regex.Match(c, @"reg(?:\.exe)?\s+query\s+""([^""]+)""\s+/v\s+(\S+)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                    if (m.Success)
                    {
                        var full = m.Groups[1].Value;
                        var valName = m.Groups[2].Value;
                        var expanded = full;
                        if (expanded.StartsWith("HKLM\\", StringComparison.OrdinalIgnoreCase)) expanded = "HKEY_LOCAL_MACHINE\\" + expanded[5..];
                        else if (expanded.StartsWith("HKCU\\", StringComparison.OrdinalIgnoreCase)) expanded = "HKEY_CURRENT_USER\\" + expanded[5..];
                        else if (expanded.StartsWith("HKCR\\", StringComparison.OrdinalIgnoreCase)) expanded = "HKEY_CLASSES_ROOT\\" + expanded[5..];
                        else if (expanded.StartsWith("HKU\\", StringComparison.OrdinalIgnoreCase)) expanded = "HKEY_USERS\\" + expanded[4..];
                        else if (expanded.StartsWith("HKCC\\", StringComparison.OrdinalIgnoreCase)) expanded = "HKEY_CURRENT_CONFIG\\" + expanded[5..];
                        var hive = expanded.StartsWith("HKEY_LOCAL_MACHINE", StringComparison.OrdinalIgnoreCase) ? Microsoft.Win32.Registry.LocalMachine
                                 : expanded.StartsWith("HKEY_CURRENT_USER", StringComparison.OrdinalIgnoreCase) ? Microsoft.Win32.Registry.CurrentUser
                                 : expanded.StartsWith("HKEY_CLASSES_ROOT", StringComparison.OrdinalIgnoreCase) ? Microsoft.Win32.Registry.ClassesRoot
                                 : expanded.StartsWith("HKEY_USERS", StringComparison.OrdinalIgnoreCase) ? Microsoft.Win32.Registry.Users
                                 : expanded.StartsWith("HKEY_CURRENT_CONFIG", StringComparison.OrdinalIgnoreCase) ? Microsoft.Win32.Registry.CurrentConfig : null;
                        if (hive == null) { result = false; return true; }
                        var path = expanded.Replace("HKEY_LOCAL_MACHINE\\", "", StringComparison.OrdinalIgnoreCase).Replace("HKEY_CURRENT_USER\\", "", StringComparison.OrdinalIgnoreCase).Replace("HKEY_CLASSES_ROOT\\", "", StringComparison.OrdinalIgnoreCase).Replace("HKEY_USERS\\", "", StringComparison.OrdinalIgnoreCase).Replace("HKEY_CURRENT_CONFIG\\", "", StringComparison.OrdinalIgnoreCase);
                        var fullLower = expanded.ToLowerInvariant();
                        using var key = OpenOsView(hive, path);
                        if (key == null) { result = false; return true; }
                        var v = key.GetValue(valName);
                        if (v == null) { result = false; return true; }
                        var expectedMatch = System.Text.RegularExpressions.Regex.Match(c, @"findstr\s+""([^""]+)""", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        if (expectedMatch.Success)
                        {
                            var needle = expectedMatch.Groups[1].Value;
                            result = v.ToString()?.Contains(needle, StringComparison.OrdinalIgnoreCase) == true
                                  || string.Format("0x{0:X}", v).Contains(needle, StringComparison.OrdinalIgnoreCase);
                            return true;
                        }
                        var find = System.Text.RegularExpressions.Regex.Match(c, @"find\s+""([^""]+)""", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        if (find.Success)
                        {
                            result = v.ToString()?.Contains(find.Groups[1].Value, StringComparison.OrdinalIgnoreCase) == true;
                            return true;
                        }
                    }
                }
                if (c.Contains("Get-ItemProperty", StringComparison.OrdinalIgnoreCase) && c.Contains("DisplayName", StringComparison.OrdinalIgnoreCase) && c.Contains("-like", StringComparison.OrdinalIgnoreCase))
                {
                    var m = System.Text.RegularExpressions.Regex.Match(c, @"DisplayName\s+-like\s+'\*?([^*']+)\*?'", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                    if (!m.Success) m = System.Text.RegularExpressions.Regex.Match(c, @"DisplayName\s+-like\s+""\*?([^*\""]+)\*?""", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                    if (m.Success)
                    {
                        var needle = m.Groups[1].Value.Trim();
                        if (!string.IsNullOrWhiteSpace(needle))
                        {
                            try
                            {
                                List<string> names;
                                lock (_uninstallLock)
                                {
                                    if (_uninstallNamesCache != null && DateTime.UtcNow < _uninstallCacheExpiry)
                                        names = _uninstallNamesCache;
                                    else
                                    {
                                        names = new List<string>();
                                        var roots = new (Microsoft.Win32.RegistryKey root, string path)[]
                                        {
                                            (Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"),
                                            (Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall"),
                                            (Microsoft.Win32.Registry.CurrentUser, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"),
                                        };
                                        foreach (var (root, path) in roots)
                                        {
                                            using var key = OpenOsView(root, path);
                                            if (key == null) continue;
                                            foreach (var sub in key.GetSubKeyNames())
                                            {
                                                using var k = key.OpenSubKey(sub);
                                                var name = k?.GetValue("DisplayName") as string;
                                                if (!string.IsNullOrWhiteSpace(name)) names.Add(name);
                                            }
                                        }
                                        _uninstallNamesCache = names;
                                        _uninstallCacheExpiry = DateTime.UtcNow.AddMinutes(5);
                                    }
                                }
                                result = names.Any(n => n.Contains(needle, StringComparison.OrdinalIgnoreCase));
                                return true;
                            } catch { }
                        }
                    }
                }
                if (c.Contains("Test-Path", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        if (c.Contains("AMD Tweaks", StringComparison.OrdinalIgnoreCase))
                        {
                            var baseDir = AppContext.BaseDirectory;
                            bool amdFound = false;
                            if (c.Contains("RadeonSoftwareSlimmer", StringComparison.OrdinalIgnoreCase)) amdFound = File.Exists(Path.Combine(baseDir, "AMD Tweaks", "RadeonSoftwareSlimmer", "RadeonSoftwareSlimmer.exe"));
                            else if (c.Contains("MoreClockTool", StringComparison.OrdinalIgnoreCase)) amdFound = File.Exists(Path.Combine(baseDir, "AMD Tweaks", "MoreClockTool.exe"));
                            else if (c.Contains("MorePowerTool", StringComparison.OrdinalIgnoreCase)) amdFound = File.Exists(Path.Combine(baseDir, "AMD Tweaks", "MorePowerTool.exe"));
                            else if (c.Contains("RadeonMod", StringComparison.OrdinalIgnoreCase)) amdFound = File.Exists(Path.Combine(baseDir, "AMD Tweaks", "RadeonMod.exe"));
                            else amdFound = Directory.Exists(Path.Combine(baseDir, "AMD Tweaks"));
                            var hasOr = c.Contains("-or", StringComparison.OrdinalIgnoreCase);
                            if (hasOr)
                            {
                                var matches = System.Text.RegularExpressions.Regex.Matches(c, @"Test-Path\s+""([^""]+)""");
                                foreach (System.Text.RegularExpressions.Match mm in matches)
                                {
                                    var p2 = ExpandOsPaths(mm.Groups[1].Value);
                                    p2 = p2.Replace("$env:LOCALAPPDATA", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)).Replace("$env:TEMP", Path.GetTempPath().TrimEnd('\\', '/')).Replace("$env:ProgramFiles", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
                                    if (File.Exists(p2) || Directory.Exists(p2)) { amdFound = true; break; }
                                }
                            }
                            result = amdFound;
                            return true;
                        }
                        var mcol = System.Text.RegularExpressions.Regex.Matches(c, @"Test-Path\s+""([^""]+)""", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        if (mcol.Count > 0)
                        {
                            foreach (System.Text.RegularExpressions.Match mm in mcol)
                            {
                                var p = ExpandOsPaths(mm.Groups[1].Value);
                                p = p.Replace("$env:LOCALAPPDATA", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)).Replace("$env:TEMP", Path.GetTempPath().TrimEnd('\\', '/')).Replace("$env:ProgramFiles", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)).Replace("$env:ProgramFiles(x86)", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86));
                                if (File.Exists(p) || Directory.Exists(p)) { result = true; return true; }
                            }
                            result = false; return true;
                        }
                        result = false; return true;
                    }
                    catch { result = false; return true; }
                }
                if (c.StartsWith("powercfg", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        var pipe = c.IndexOf('|');
                        var head = (pipe < 0 ? c : c[..pipe]).Trim();
                        var needle = "";
                        var fm = System.Text.RegularExpressions.Regex.Match(c, @"find\s+""([^""]+)""", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        if (fm.Success) needle = fm.Groups[1].Value;
                        var psi = new System.Diagnostics.ProcessStartInfo("powercfg", head.Substring("powercfg".Length).Trim())
                        {
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };
                        using var proc = System.Diagnostics.Process.Start(psi);
                        if (proc == null) { result = false; return true; }
                        var output = proc.StandardOutput.ReadToEnd();
                        proc.WaitForExit(8000);
                        result = needle.Length == 0 || output.Contains(needle, StringComparison.OrdinalIgnoreCase);
                        return true;
                    }
                    catch { result = false; return true; }
                }
                if (c.Contains("sc query", StringComparison.OrdinalIgnoreCase) || c.Contains("Get-Service", StringComparison.OrdinalIgnoreCase))
                    return false;
            }
        } catch { }
        return false;
    }

    private void TryDetectComboSelection()
    {
        try
        {
            if (_action.Id == "hop-limit")
            {
                using var k = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters");
                var v = k?.GetValue("DefaultTTL");
                if (v is int i)
                {
                    var label = i == 65 ? "Bypass (65)" : i == 64 ? "Repeater (64)" : "Default (128)";
                    var opt = Options.FirstOrDefault(o => o.Option.Label == label);
                    if (opt != null) SelectedOption = opt;
                }
            }
            else if (_action.Id == "fivem-safe-services")
            {
                using var k1 = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\DiagTrack");
                var s = k1?.GetValue("Start");
                var isSafe = s is int iv && iv == 4;
                var label = isSafe ? "Safe FiveM/Minecraft Services" : "Superiorly Default";
                var opt = Options.FirstOrDefault(o => o.Option.Label == label);
                if (opt != null) SelectedOption = opt;
            }
        } catch { }
    }
}
