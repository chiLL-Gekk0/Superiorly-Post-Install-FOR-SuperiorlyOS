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

    // probe roots that are too broad to walk; anything narrower (tool folders, package dirs) is safe and cheap
    private static readonly string[] ScanBlockedRoots =
    {
        Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
        Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
        Environment.GetFolderPath(Environment.SpecialFolder.Windows),
        Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
    };

    private static bool TryFastCheckInner(IReadOnlyList<string> checks, out bool result)
    {
        result = false;
        var handled = false;
        try
        {
            foreach (var c in checks)
            {
                if (c.StartsWith("file:", StringComparison.OrdinalIgnoreCase))
                {
                    handled = true;
                    var pattern = ExpandOsPaths(c[5..].Trim());
                    if (pattern.IndexOf('*') < 0)
                    {
                        if (File.Exists(pattern)) { result = true; break; }
                        continue;
                    }
                    try
                    {
                        var fileName = Path.GetFileName(pattern);
                        if (string.IsNullOrEmpty(fileName) || fileName.Contains('*'))
                            fileName = "*";
                        var rootPart = pattern.Contains("**", StringComparison.Ordinal)
                            ? pattern[..pattern.IndexOf("**", StringComparison.Ordinal)].TrimEnd('\\', '/')
                            : Path.GetDirectoryName(pattern[..pattern.IndexOf('*')]) ?? "";
                        rootPart = ExpandOsPaths(rootPart).TrimEnd('\\', '/');
                        if (string.IsNullOrEmpty(rootPart) || !Directory.Exists(rootPart)) continue;
                        foreach (var blocked in ScanBlockedRoots)
                            if (rootPart.Equals(blocked.TrimEnd('\\', '/'), StringComparison.OrdinalIgnoreCase)) { rootPart = ""; break; }
                        if (string.IsNullOrEmpty(rootPart)) continue;
                        if (Directory.EnumerateFiles(rootPart, fileName, SearchOption.TopDirectoryOnly).Any()) { result = true; break; }
                        if (Directory.EnumerateDirectories(rootPart).Any()
                            && Directory.EnumerateFiles(rootPart, fileName, SearchOption.AllDirectories).Any()) { result = true; break; }
                    }
                    catch { }
                    continue;
                }
                if (c.IndexOf("reg", StringComparison.OrdinalIgnoreCase) >= 0 && c.IndexOf("query", StringComparison.OrdinalIgnoreCase) >= 0 && c.Contains("/v", StringComparison.OrdinalIgnoreCase))
                {
                    handled = true;
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
                        if (hive == null) continue;
                        var path = expanded.Replace("HKEY_LOCAL_MACHINE\\", "", StringComparison.OrdinalIgnoreCase).Replace("HKEY_CURRENT_USER\\", "", StringComparison.OrdinalIgnoreCase).Replace("HKEY_CLASSES_ROOT\\", "", StringComparison.OrdinalIgnoreCase).Replace("HKEY_USERS\\", "", StringComparison.OrdinalIgnoreCase).Replace("HKEY_CURRENT_CONFIG\\", "", StringComparison.OrdinalIgnoreCase);
                        using var key = OpenOsView(hive, path);
                        if (key == null) continue;
                        var v = key.GetValue(valName);
                        if (v == null) continue;
                        var text = v.ToString() ?? "";
                        var hex = string.Format("0x{0:X}", v);
                        var expectedMatch = System.Text.RegularExpressions.Regex.Match(c, @"findstr\s+""([^""]+)""", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        if (expectedMatch.Success)
                        {
                            var needle = expectedMatch.Groups[1].Value;
                            if (text.Contains(needle, StringComparison.OrdinalIgnoreCase) || hex.Contains(needle, StringComparison.OrdinalIgnoreCase)) { result = true; break; }
                            continue;
                        }
                        var find = System.Text.RegularExpressions.Regex.Match(c, @"find\s+""([^""]+)""", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        if (find.Success)
                        {
                            if (text.Contains(find.Groups[1].Value, StringComparison.OrdinalIgnoreCase)) { result = true; break; }
                            continue;
                        }
                    }
                }
                if (c.Contains("Get-ItemProperty", StringComparison.OrdinalIgnoreCase) && c.Contains("DisplayName", StringComparison.OrdinalIgnoreCase) && c.Contains("-like", StringComparison.OrdinalIgnoreCase))
                {
                    handled = true;

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
                                if (names.Any(n => n.Contains(needle, StringComparison.OrdinalIgnoreCase))) { result = true; break; }
                            } catch { }
                        }
                    }
                }
                if (c.Contains("Test-Path", StringComparison.OrdinalIgnoreCase))
                {
                    handled = true;
                    try
                    {
                        var mcol = System.Text.RegularExpressions.Regex.Matches(c, @"Test-Path\s+""([^""]+)""", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        if (mcol.Count > 0)
                        {
                            foreach (System.Text.RegularExpressions.Match mm in mcol)
                            {
                                var p = ExpandOsPaths(mm.Groups[1].Value);
                                p = p.Replace("$env:LOCALAPPDATA", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)).Replace("$env:TEMP", Path.GetTempPath().TrimEnd('\\', '/')).Replace("$env:ProgramFiles", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)).Replace("$env:ProgramFiles(x86)", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86));
                                if (File.Exists(p) || Directory.Exists(p)) { result = true; break; }
                            }
                            if (result) break;
                            continue;
                        }
                        continue;
                    }
                    catch { continue; }
                }
                if (c.StartsWith("powercfg", StringComparison.OrdinalIgnoreCase))
                {
                    handled = true;
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
                        if (proc == null) continue;
                        var output = proc.StandardOutput.ReadToEnd();
                        proc.WaitForExit(8000);
                        if (needle.Length == 0 || output.Contains(needle, StringComparison.OrdinalIgnoreCase)) { result = true; break; }
                        continue;
                    }
                    catch { continue; }
                }
            }
        }
        catch { }
        // every probe was understood: the OR verdict stands
        return handled;
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
            else if (_action.Id == "hibernation")
            {
                using var k = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Power");
                var explicitOn = k?.GetValue("HibernateEnabled") as int?;
                var fallbackOn = k?.GetValue("HibernateEnabledDefault") as int?;
                // a factory install can have neither value, so fall back to the file itself
                var hiber = System.IO.Path.Combine(Environment.GetEnvironmentVariable("SystemDrive") ?? "C:", "hiberfil.sys");
                var enabled = explicitOn == 1 || (explicitOn is null && fallbackOn != 0) || System.IO.File.Exists(hiber);
                // HiberFileType only counts while HiberFileSizePercent < 40; above it the file is full
                var percent = k?.GetValue("HiberFileSizePercent") as int?;
                var type = k?.GetValue("HiberFileType") as int?;
                var label = !enabled ? "Disabled" : type == 1 && (percent is null || percent < 40) ? "Reduced" : "Full";
                var opt = Options.FirstOrDefault(o => o.Option.Label == label);
                if (opt != null) SelectedOption = opt;
            }
        } catch { }
    }
}
