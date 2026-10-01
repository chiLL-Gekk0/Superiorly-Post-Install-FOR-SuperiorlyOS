using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

public partial class CardViewModel : ObservableObject {

    // embedded nips, extracted on demand, sha256 verified where pinned; no downloads
    private static readonly (string Name, string Sha)[] MirrorNips =
    {
        ("EXPERIMENTAL-LLM-ON-RENDERS-DEF.nip", "AD79219730A3364C2DE37824E16FA5766F88A3FDDFEE148BCACED2D89814D329"),
        ("EXPERIMENTAL-LLM-ON-RENDERS-DEF-V2.nip", "897B733242FB9160C6224B8D6B036D3CC27F37A3F1B90367A42EB5119F312274"),
        ("EXPERIMENTAL-LLM-ON-RENDERS-DEF-PREFETCH+RTCORE-V2.nip", "B48F3DB395E0E6758D9B4487360CD7FC65862443E07695B67824A587B3C31BD2"),
        ("EXPERIMENTAL-AGGRESSIVE-TEST.nip", "AA149815190F3B0E17B4B899AC6C1D90C7BB51CA03424B4E07BECCBC337A4A07"),
        ("Global-Test-Experimental.nip", "1E1147EF1A36FA231F67BC098981E8A659066E02BC1EA496E1627B851D65CE02"),
        ("Latency-Test-Experimental.nip", "B0580C050C689D62E21897F953980FA874D5EFAE4ABC8F6433D3F48C7E9B1BFF"),
        ("KernelOS Performance v2.nip", ""),
        ("KernelOS Performance v2.1.nip", ""),
        ("KernelOS Performance v3.nip", ""),
    };

    private static int _nipFetchState;
    private static string? _npiExe;

    private static string? EnsureNpiExe()
    {
        try
        {
            if (_npiExe != null && File.Exists(_npiExe)) return _npiExe;
            var dir = Path.Combine(AppContext.BaseDirectory, "Tools", "npi");
            Directory.CreateDirectory(dir);
            var exe = Path.Combine(dir, "nvidiaProfileInspector.exe");
            if (!File.Exists(exe))
            {
                using var s = typeof(CardViewModel).Assembly.GetManifestResourceStream("Superiorly.PostInstall.tools.npi.exe");
                if (s == null) return null;
                using var fs = File.Create(exe);
                s.CopyTo(fs);
            }
            _npiExe = exe;
            return exe;
        }
        catch { return null; }
    }

    private async Task EnsureNipsAsync()
    {
        if (System.Threading.Interlocked.CompareExchange(ref _nipFetchState, 1, 0) != 0) return;
        try
        {
            var nipDir = Path.Combine(AppContext.BaseDirectory, "Nvidia Profiles");
            try { Directory.CreateDirectory(nipDir); } catch { return; }
            foreach (var n in MirrorNips)
            {
                var dest = Path.Combine(nipDir, n.Name);
                if (!File.Exists(dest))
                {
                    try
                    {
                        using var s = typeof(CardViewModel).Assembly.GetManifestResourceStream(n.Name);
                        if (s == null) continue;
                        using var fs = File.Create(dest);
                        s.CopyTo(fs);
                    }
                    catch { continue; }
                }
                if (string.IsNullOrEmpty(n.Sha)) continue;
                try
                {
                    using var sha = System.Security.Cryptography.SHA256.Create();
                    using var fh = File.OpenRead(dest);
                    if (!Convert.ToHexString(sha.ComputeHash(fh)).Equals(n.Sha, StringComparison.OrdinalIgnoreCase))
                    { try { File.Delete(dest); } catch { } }
                }
                catch { }
            }
            var d = System.Windows.Application.Current?.Dispatcher;
            if (d != null) await d.InvokeAsync(LoadNipProfiles);
        }
        finally { System.Threading.Interlocked.Exchange(ref _nipFetchState, 0); }
    }
    private void LoadNipProfiles()
    {
        var nipDir = Path.Combine(AppContext.BaseDirectory, "Nvidia Profiles");
        var keep = SelectedOption?.Label;
        Options.Clear();
        string[] nipFiles = System.Array.Empty<string>();
        try { if (Directory.Exists(nipDir)) nipFiles = Directory.GetFiles(nipDir, "*.nip"); } catch { }
        System.Array.Sort(nipFiles, System.StringComparer.OrdinalIgnoreCase);
        if (nipFiles.Length == 0)
        {
            Options.Add(new OptionViewModel(this, new ActionOption { Label = TranslationService.GetUi("no_profiles_found", Lang), Commands = new List<string>() }));
            SelectedOption = null;
            OnPropertyChanged(nameof(IsCombo));
            OnPropertyChanged(nameof(IsPresetCombo));
            OnPropertyChanged(nameof(ActionButtonLabel));
            ApplyCommand.NotifyCanExecuteChanged();
            return;
        }
        foreach (var file in nipFiles)
        {
            var name = Path.GetFileNameWithoutExtension(file);
            var npi = EnsureNpiExe();
            string cmd;
            if (npi != null)
            {
                cmd = $"powershell -NoProfile -ExecutionPolicy Bypass -Command " +
                    $"& '{npi}' -silentImport '{file}'";
            }
            else
            {
                cmd = "powershell -NoProfile -ExecutionPolicy Bypass -Command Add-Type -AssemblyName System.Windows.Forms -EA 0; [System.Windows.Forms.MessageBox]::Show('nvidiaProfileInspector is missing and offline mode cannot download it.','Apply NIP',0,64); exit 1";
            }

            var opt = new ActionOption { Label = name, Commands = new List<string> { cmd } };
            Options.Add(new OptionViewModel(this, opt));
        }
        SelectedOption = Options.FirstOrDefault(o => keep != null && o.Label == keep) ?? Options.FirstOrDefault();
        OnPropertyChanged(nameof(IsCombo));
        OnPropertyChanged(nameof(IsPresetCombo));
        OnPropertyChanged(nameof(ActionButtonLabel));
        ApplyCommand.NotifyCanExecuteChanged();
    }

    private void LoadAmdTool()
    {
        var amdDir = Path.Combine(AppContext.BaseDirectory, "AMD Tweaks");
        if (!Directory.Exists(amdDir)) return;

        var exeMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["radeonsoftwareslimmer"] = Path.Combine(amdDir, "RadeonSoftwareSlimmer", "RadeonSoftwareSlimmer.exe"),
            ["moreclocktool"] = Path.Combine(amdDir, "MoreClockTool.exe"),
            ["morepowertool"] = Path.Combine(amdDir, "MorePowerTool.exe"),
            ["radeonmod"] = Path.Combine(amdDir, "RadeonMod.exe"),
        };

        if (!exeMap.TryGetValue(_action.Id, out var exePath) || !File.Exists(exePath)) return;
        Options.Clear();
        Options.Add(new OptionViewModel(this, new ActionOption { Label = "Run", Commands = new List<string> { $"Start-Process '{exePath}'" } }));
        SelectedOption = Options.FirstOrDefault();
    }

    private void LoadCruTools()
    {
        var cruDir = Path.Combine(AppContext.BaseDirectory, "Tools", "cru");
        string? foundDir = Directory.Exists(cruDir) ? cruDir : null;
        string? cruExe = foundDir != null ? Directory.GetFiles(foundDir, "CRU.exe", SearchOption.AllDirectories).FirstOrDefault() : null;
        string? restartExe = foundDir != null ? Directory.GetFiles(foundDir, "restart64.exe", SearchOption.AllDirectories).FirstOrDefault() : null;
        string? resetExe = foundDir != null ? Directory.GetFiles(foundDir, "reset-all.exe", SearchOption.AllDirectories).FirstOrDefault() : null;

        Options.Clear();

        if (cruExe != null)
        {
            Options.Add(new OptionViewModel(this, new ActionOption { Label = "Open CRU", Commands = new List<string> { $"Start-Process '{cruExe}'" } }));
            if (restartExe != null)
                Options.Add(new OptionViewModel(this, new ActionOption { Label = "Restart Display Driver", Commands = new List<string> { $"Start-Process '{restartExe}' -ArgumentList '/q'" } }));
            if (resetExe != null)
                Options.Add(new OptionViewModel(this, new ActionOption { Label = "Reset All", Commands = new List<string> { $"Start-Process '{resetExe}' -ArgumentList '/q'" } }));
        }

        if (Options.Count == 0)
        {
            var dlCmd = "powershell -NoProfile -ExecutionPolicy Bypass -Command Add-Type -AssemblyName System.Windows.Forms -EA 0; [System.Windows.Forms.MessageBox]::Show('CRU not found locally. Place CRU.exe, restart64.exe and reset-all.exe in a CRU folder, then retry.','CRU',0,64); exit 1";
            Options.Add(new OptionViewModel(this, new ActionOption { Label = "Download CRU", Commands = new List<string> { dlCmd } }));
        }

        SelectedOption = Options.FirstOrDefault();
    }

    private void OpenQuantumMap()
    {
        _owner.ShowQuantumMap(Win32PreviewHex, hex =>
        {
            int v = Convert.ToInt32(hex.Replace("0x", ""), 16);
            int psMap = (v >> 4) & 0x3;
            Win32SelectedPs = psMap == 2 ? "1:1" : psMap == 1 ? "2:1" : "3:1";
            Win32IntervalLong = (v & 0x8) != 0;
            Win32LengthFixed = (v & 0x4) != 0;
            Win32PreviewHex = $"0x{v:X2}";
            Win32PreviewBinary = Convert.ToString(v, 2).PadLeft(6, '0');
            _ = Win32ApplyAsync();
        });
    }

    private static ActionOption? FindOption(ActionItem action, string label) =>
        action.Options.FirstOrDefault(o => o.Label.Equals(label, StringComparison.OrdinalIgnoreCase));

    partial void OnRunningChanged(bool value)
    {
        OnPropertyChanged(nameof(IsBusy));
        OnPropertyChanged(nameof(ActionButtonLabel));
        foreach (var option in Options) option.RunCommand.NotifyCanExecuteChanged();
        ToggleCommand.NotifyCanExecuteChanged();
        ApplyCommand.NotifyCanExecuteChanged();
            UnselectAllCommand.NotifyCanExecuteChanged();
            SelectAllCommand.NotifyCanExecuteChanged();
        LoadItemsCommand.NotifyCanExecuteChanged();
        Win32ApplyCommand.NotifyCanExecuteChanged();
        InstallSelectedCommand.NotifyCanExecuteChanged();
        ActivatePowerPlanCommand.NotifyCanExecuteChanged();
        DeletePowerPlanCommand.NotifyCanExecuteChanged();
        ImportPowerPlanCommand.NotifyCanExecuteChanged();
        ExportPowerPlanCommand.NotifyCanExecuteChanged();
    }

    partial void OnSelectedOptionChanged(OptionViewModel? value)
    {
        ApplyCommand.NotifyCanExecuteChanged();
    }

    private void OnItemPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(PowerPlanItem.IsChecked))
        {
            OnPropertyChanged(nameof(HasCheckedItems));
            OnPropertyChanged(nameof(HasCheckedCustomItems));
            OnPropertyChanged(nameof(CheckedCount));
            DeletePowerPlanCommand.NotifyCanExecuteChanged();
            ActivatePowerPlanCommand.NotifyCanExecuteChanged();
            ExportPowerPlanCommand.NotifyCanExecuteChanged();
            UnselectAllCommand.NotifyCanExecuteChanged();
            SelectAllCommand.NotifyCanExecuteChanged();
        }
    }
}
