using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

public partial class CardViewModel : ObservableObject {

    internal async Task RunAsync(ActionOption option)
    {
        if (option.Commands.Count == 0) return;
        // allow search re-entry to cancel prior run
        var isSearchRetry = IsSearchCard && option.Label.Equals("Search", StringComparison.OrdinalIgnoreCase) && Running;
        if (Running && !isSearchRetry) return;
        if (isSearchRetry) { try { _cts?.Cancel(); } catch { } }

        Running = true;
        _cts = new CancellationTokenSource();
        var myCts = _cts;
        try
        {

        var wasInstalled = IsOn;
        var commands = option.Commands;
        if (wasInstalled && _launch.Count > 0)
            commands = _launch.ToList();
        if (IsSearchCard && !string.IsNullOrEmpty(UserInput))
        {
            var query = UserInput.Trim();
            var match = System.Text.RegularExpressions.Regex.Match(query, @"(?:apps\.microsoft\.com.*?/|[?&]productId=)([A-Za-z0-9]{12,})");
            if (match.Success) query = match.Groups[1].Value;
            commands = commands.Select(c => c.Replace("{query}", query)).ToList();
        }

        var isLong = PowerShellHelper.IsLongRunning(commands);
        bool ok;

        if (isLong)
        {
            var cached = PowerShellHelper.IsAlreadyCached(commands);
            var isServiceOp = commands.Any(c => { var t = c.TrimStart(); return t.StartsWith("dism ", StringComparison.OrdinalIgnoreCase) || t.StartsWith("sc.exe ", StringComparison.OrdinalIgnoreCase); });
            _owner.ShowProgress(Title, isServiceOp ? string.Format(TranslationService.GetUi("applying", Lang), Title) : cached ? string.Format(TranslationService.GetUi("starting", Lang), Title) : string.Format(TranslationService.GetUi("downloading", Lang), Title));
            try
            {
                var progress = new Progress<int>(pct => _owner.UpdateProgress(pct));
                ok = await _downloadRunner.RunAllAsync(commands, progress, _cts.Token, cached);
            }
            finally
            {
                _owner.HideProgress();
            }
        }
        else if (IsSearchCard && option.Label.Equals("Search", StringComparison.OrdinalIgnoreCase))
        {
            IsSearching = true;
            StoreResults.Clear();
            try
            {
                var rawQuery = UserInput.Trim();
                if (string.IsNullOrWhiteSpace(rawQuery))
                {
                    ok = false;
                }
                else
                {
                    SearchExecuted = true;
                    var progress = new Progress<StoreHit>(hit =>
                    {
                        if (!ReferenceEquals(_cts, myCts)) return;
                        if (StoreResults.Any(r => r.PackageId.Equals(hit.PackageId, StringComparison.OrdinalIgnoreCase))) return;
                        StoreResults.Add(new StoreResultItem { Name = hit.Name, PackageId = hit.PackageId, Publisher = hit.Publisher, Source = hit.Source });
                    });
                    var hits = await _storeSearch.SearchAsync(rawQuery, progress, _cts.Token);
                    if (!ReferenceEquals(_cts, myCts) || myCts.IsCancellationRequested)
                    {
                        ok = false;
                    }
                    else
                    {
                        StoreResults.Clear();
                        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                        foreach (var hit in hits)
                        {
                            if (!seen.Add(hit.PackageId)) continue;
                            StoreResults.Add(new StoreResultItem { Name = hit.Name, PackageId = hit.PackageId, Publisher = hit.Publisher, Source = hit.Source });
                        }
                        ok = StoreResults.Count > 0;
                    }
                }
            }
            catch
            {
                ok = false;
            }
            finally
            {
                if (ReferenceEquals(_cts, myCts)) IsSearching = false;
            }
        }
        else
        {
            ok = await Task.Run(() => _runner.RunAll(commands), _cts.Token);
        }

        var installDidLaunch = commands.Any(c => c.Contains("Start-Process", StringComparison.OrdinalIgnoreCase) && !c.Contains("Start-Process https", StringComparison.OrdinalIgnoreCase));
        if (ok && _launch.Count > 0 && !IsOn && !installDidLaunch)
        {
            try { await Task.Run(() => _runner.RunAll(_launch), _cts.Token); } catch { }
            await RefreshStateAsync();
        }

        var isWebOnly = commands.Any(c => c.Contains("Start-Process https", StringComparison.OrdinalIgnoreCase));
        var isToggle = ReferenceEquals(option, _enableOption) || ReferenceEquals(option, _disableOption);
        if (ok && !wasInstalled && !isToggle && !IsPresetCombo && _checks.Count > 0 && !isWebOnly && !installDidLaunch)
        {
            await RefreshStateAsync();
            if (!IsOn) ok = false;
        }
        if (ok && installDidLaunch) await RefreshStateAsync();
        var notifyPath = ok && _launch.Count > 0 ? (string?)_launch[0] : null;
        if (ok)
        {
            if (!IsSearchCard)
            {
                var toggleKey = ReferenceEquals(option, _enableOption) ? "enabled"
                    : ReferenceEquals(option, _disableOption) ? "disabled" : null;
                var action = toggleKey != null
                    ? Services.TranslationService.GetNotification(toggleKey, _owner.SelectedLanguage.Code)
                    : IsPresetCombo
                    ? Services.TranslationService.GetNotification("applied", _owner.SelectedLanguage.Code)
                    : (wasInstalled || isWebOnly)
                    ? Services.TranslationService.GetNotification("opened", _owner.SelectedLanguage.Code)
                    : Services.TranslationService.GetNotification("installed", _owner.SelectedLanguage.Code);
                _owner.Notify($"{Title}: {action}", notifyPath, Title, char.ConvertFromUtf32(0xE896));
            }
        }
        else if (!IsSearchCard && !isToggle)
        {
            var key = IsPresetCombo ? "apply_failed" : wasInstalled ? "open_failed" : "failed";
            var failed = Services.TranslationService.GetNotification(key, _owner.SelectedLanguage.Code);
                _owner.Notify($"{Title}: {failed}", notifyPath, Title, char.ConvertFromUtf32(0xE711));
        }
        }
        finally
        {
            if (ReferenceEquals(_cts, myCts)) { Running = false; _cts?.Dispose(); _cts = null; }
        }
    }

    private async Task LoadItemsAsync(bool silent = false)
    {
        if (Running) return;
        if (HasItems)
        {
            Items.Clear();
            OnPropertyChanged(nameof(HasItems));
            _owner.Notify($"{Title}: {TranslationService.GetUi("list_unloaded", Lang)}", null, Title, char.ConvertFromUtf32(0xE721));
            return;
        }
        Running = true;
        try
        {
        Items.Clear();

        if (_action.Id == "powerplan-manager")
        {
            if (!silent) _owner.UpdateProgress(50, TranslationService.GetUi("reading_plans", Lang));
            await RefreshPowerPlansAsync();
        }

        if (!silent) _owner.UpdateProgress(100, string.Format(TranslationService.GetUi("apps_found", Lang), Items.Count));
        OnPropertyChanged(nameof(HasItems));
        if (!silent) _owner.Notify(Items.Count == 0 ? Title + ": " + TranslationService.GetUi("nothing_found", Lang) : string.Format(TranslationService.GetUi("loaded_items", Lang), Items.Count), null, Title, Items.Count == 0 ? char.ConvertFromUtf32(0xE711) : char.ConvertFromUtf32(0xE73E));
        }
        finally
        {
            if (!silent) _owner.HideProgress();
            Running = false;
        }
    }


    private string CapturePowerShell(string command)
    {
        try
        {
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = PowerShellExe,
                Arguments = $"-NoProfile -Command \"{command}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using var proc = System.Diagnostics.Process.Start(psi)!;
            var output = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit(15000);
            return output;
        }
        catch { return ""; }
    }

    private async Task RunPowerShellElevatedAsync(string command)
    {
        await Task.Run(() =>
        {
            try
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                FileName = PowerShellExe,
                Arguments = $"-NoProfile -Command \"{command}\"",
                Verb = "runAs",
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
                };
                using var proc = System.Diagnostics.Process.Start(psi);
                proc?.WaitForExit(30000);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                    System.Windows.MessageBox.Show(TranslationService.GetUi("needs_admin", Lang), Title, System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning));
            }
        });
    }
}
