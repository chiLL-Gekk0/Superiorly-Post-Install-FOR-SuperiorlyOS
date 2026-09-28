using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

public partial class CardViewModel : ObservableObject {

    private async Task ActivatePowerPlanAsync()
    {
        var plan = Items.OfType<PowerPlanItem>().FirstOrDefault(p => p.IsChecked);
        if (plan == null) return;
        await RunPowerShellElevatedAsync($"powercfg /setactive {plan.Guid}");
        await RefreshPowerPlansAsync();
    }

    private async Task DeletePowerPlanAsync()
    {
        // ponytail: never delete official Microsoft schemes — customs only
        var selected = Items.OfType<PowerPlanItem>().Where(p => p.IsChecked && !p.IsOfficial).ToList();
        if (selected.Count == 0) return;
        if (selected.Any(p => p.IsActive))
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
                System.Windows.MessageBox.Show(TranslationService.GetUi("cant_delete_active", Lang), Title, System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning));
            return;
        }
        var msg = string.Format(TranslationService.GetUi("delete_plans", Lang), selected.Count) + "\n" + string.Join("\n", selected.Select(s => "• " + s.Name));
        var confirm = await _owner.ShowConfirmAsync(TranslationService.GetUi("confirm_delete", Lang), msg);
        if (!confirm) return;
        foreach (var plan in selected)
            await RunPowerShellElevatedAsync($"powercfg /delete {plan.Guid}");
        await RefreshPowerPlansAsync();
    }

    private async Task ImportPowerPlanAsync()
    {
        var dialog = new Microsoft.Win32.OpenFileDialog
        {
            Filter = $"{TranslationService.GetUi("power_plan_filter", Lang)} (*.pow)|*.pow",
            Title = TranslationService.GetUi("import_plan", Lang)
        };
        if (dialog.ShowDialog() != true) return;
        var importCmd = $"powercfg /import \"{dialog.FileName}\"";
        await RunPowerShellElevatedAsync(importCmd);
        await RefreshPowerPlansAsync();
    }

    private async Task ExportPowerPlanAsync()
    {
        var plan = Items.OfType<PowerPlanItem>().FirstOrDefault(p => p.IsChecked);
        if (plan == null) return;
        var dialog = new Microsoft.Win32.SaveFileDialog
        {
            Filter = $"{TranslationService.GetUi("power_plan_filter", Lang)} (*.pow)|*.pow",
            FileName = $"{plan.Name}.pow",
            Title = TranslationService.GetUi("export_plan", Lang)
        };
        if (dialog.ShowDialog() != true) return;
        await RunPowerShellElevatedAsync($"powercfg /export \"{dialog.FileName}\" {plan.Guid}");
        if (!System.IO.File.Exists(dialog.FileName)) { _owner.Notify(TranslationService.GetUi("update_check_failed", Lang), null, TranslationService.GetTabTitle("powerplans", Lang), char.ConvertFromUtf32(0xE711)); return; }
        _owner.Notify(string.Format(TranslationService.GetUi("exported", Lang), plan.Name), dialog.FileName, TranslationService.GetTabTitle("powerplans", Lang), char.ConvertFromUtf32(0xE7E8));
    }

    private async Task RefreshPowerPlansAsync()
    {
        ApplyPlans(await FetchPlanRowsAsync(), preserveChecks: true);
    }

    private static string? _powerPlanOutputCache;

    // ponytail: warmed once at startup so the card paints instantly; refresh still runs in background
    public static void WarmupPowerPlans()
    {
        _ = Task.Run(() =>
        {
            try
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = PowerShellExe,
                    Arguments = "-NoProfile -Command \"powercfg /list\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                using var proc = System.Diagnostics.Process.Start(psi)!;
                var output = proc.StandardOutput.ReadToEnd();
                proc.WaitForExit(15000);
                if (!string.IsNullOrWhiteSpace(output)) _powerPlanOutputCache = output;
            }
            catch { }
        });
    }

    private async Task<List<PowerPlanItem>> FetchPlanRowsAsync()
    {
        var output = _powerPlanOutputCache ?? await Task.Run(() => CapturePowerShell("powercfg /list"));
        _powerPlanOutputCache = output;
        var missingOfficial = OfficialPlanGuids.Where(g => !output.Contains(g, StringComparison.OrdinalIgnoreCase)).ToList();
        var missingCustom = CustomPlanGuids.Where(g => !output.Contains(g, StringComparison.OrdinalIgnoreCase)).ToList();
        var allMissing = missingOfficial.Concat(missingCustom).ToList();
        if (allMissing.Count > 0)
        {
            foreach (var guid in allMissing)
                await RunPowerShellElevatedAsync($"powercfg -duplicatescheme {guid} {guid}");
            output = await Task.Run(() => CapturePowerShell("powercfg /list"));
        }
        return ParsePlanOutput(output);
    }

    private static List<PowerPlanItem> ParsePlanOutput(string output)
    {
        var plans = new List<PowerPlanItem>();
        foreach (var line in output.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries))
        {
            var match = System.Text.RegularExpressions.Regex.Match(line,
                @"Power Scheme GUID: ([0-9a-f-]+)\s+\(([^)]+)\)(\s*\*)?");
            if (!match.Success) continue;
            plans.Add(new PowerPlanItem
            {
                Guid = match.Groups[1].Value,
                Name = match.Groups[2].Value,
                IsActive = match.Groups[3].Success
            });
        }
        return plans;
    }

    private void ApplyPlans(IEnumerable<PowerPlanItem> rows, bool preserveChecks = false)
    {
        var checkedGuids = preserveChecks
            ? Items.OfType<PowerPlanItem>().Where(i => i.IsChecked).Select(i => i.Guid).ToHashSet(StringComparer.OrdinalIgnoreCase)
            : new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        Items.Reset(rows.GroupBy(p => p.Name.Trim(), StringComparer.OrdinalIgnoreCase)
                                  .Select(g => g.FirstOrDefault(p => p.IsActive) ?? g.First())
                                  .Select(p => { p.IsOfficial = OfficialPlanGuids.Contains(p.Guid); return p; })
                                  .OrderByDescending(p => p.IsActive)
                                  .ThenByDescending(p => p.IsOfficial)
                                  .ThenBy(p => p.Name, StringComparer.OrdinalIgnoreCase));
        if (checkedGuids.Count > 0)
            foreach (var it in Items.OfType<PowerPlanItem>())
                if (checkedGuids.Contains(it.Guid)) it.IsChecked = true;
        RefreshPlanViews();
        OnPropertyChanged(nameof(HasCheckedCustomItems));
    }

    private static readonly HashSet<string> OfficialPlanGuids = new(StringComparer.OrdinalIgnoreCase)
    {
        "a1841308-3541-4fab-bc81-f71556f20b4a",
        "381b4222-f694-41f0-9685-ff5bb260df2e",
        "8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c",
    };

    private static readonly HashSet<string> CustomPlanGuids = new(StringComparer.OrdinalIgnoreCase)
    {
        "15e0857a-e830-4611-b1f6-24983b325808",
        "17385834-b667-4ebf-a623-9fc06815b12d",
        "230dc311-b7f1-49a1-a77b-3f0dfc530471",
        "33623235-3932-3063-3439-623264323964",
        "499fc2fa-9858-4aff-a8be-b79276d5c6cd",
        "71cff58f-6d53-4625-aef5-d45593d202cb",
        "752c61a5-12c9-4ea4-b50e-defa458690c2",
        "b1e8c586-7070-429f-8b59-e667f478fecc",
        "f3652fce-bc93-4a28-baca-08c4d4dbbfe2",
    };

    public System.ComponentModel.ICollectionView? OfficialPlansView { get; private set; }
    public System.ComponentModel.ICollectionView? CustomPlansView { get; private set; }

    private void RefreshPlanViews()
    {
        var official = new System.Windows.Data.CollectionViewSource { Source = Items }.View;
        official.Filter = o => o is PowerPlanItem p && p.IsOfficial;
        OfficialPlansView = official;

        var custom = new System.Windows.Data.CollectionViewSource { Source = Items }.View;
        custom.Filter = o => o is PowerPlanItem p && !p.IsOfficial;
        CustomPlansView = custom;

        OnPropertyChanged(nameof(OfficialPlansView));
        OnPropertyChanged(nameof(CustomPlansView));
    }
}
