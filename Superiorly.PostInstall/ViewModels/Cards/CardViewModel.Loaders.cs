using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

public partial class CardViewModel : ObservableObject {

    // experimental nips from public mirror, sha256 verified, cached locally
    private static readonly (string Name, string Url, string Sha)[] MirrorNips =
    {
        ("EXPERIMENTAL-LLM-ON-RENDERS-DEF.nip", "https://raw.githubusercontent.com/chiLL-Gekk0/Superiorly-PostInstall-Assets/main/Nvidia%20Profiles/EXPERIMENTAL-LLM-ON-RENDERS-DEF.nip", "AD79219730A3364C2DE37824E16FA5766F88A3FDDFEE148BCACED2D89814D329"),
        ("EXPERIMENTAL-LLM-ON-RENDERS-DEF-V2.nip", "https://raw.githubusercontent.com/chiLL-Gekk0/Superiorly-PostInstall-Assets/main/Nvidia%20Profiles/EXPERIMENTAL-LLM-ON-RENDERS-DEF-V2.nip", "897B733242FB9160C6224B8D6B036D3CC27F37A3F1B90367A42EB5119F312274"),
        ("EXPERIMENTAL-LLM-ON-RENDERS-DEF-PREFETCH+RTCORE-V2.nip", "https://raw.githubusercontent.com/chiLL-Gekk0/Superiorly-PostInstall-Assets/main/Nvidia%20Profiles/EXPERIMENTAL-LLM-ON-RENDERS-DEF-PREFETCH%2BRTCORE-V2.nip", "B48F3DB395E0E6758D9B4487360CD7FC65862443E07695B67824A587B3C31BD2"),
        ("EXPERIMENTAL-AGGRESSIVE-TEST.nip", "https://raw.githubusercontent.com/chiLL-Gekk0/Superiorly-PostInstall-Assets/main/Nvidia%20Profiles/EXPERIMENTAL-AGGRESSIVE-TEST.nip", "AA149815190F3B0E17B4B899AC6C1D90C7BB51CA03424B4E07BECCBC337A4A07"),
        ("Global-Test-Experimental.nip", "https://raw.githubusercontent.com/chiLL-Gekk0/Superiorly-PostInstall-Assets/main/Nvidia%20Profiles/Global-Test-Experimental.nip", "1E1147EF1A36FA231F67BC098981E8A659066E02BC1EA496E1627B851D65CE02"),
        ("Latency-Test-Experimental.nip", "https://raw.githubusercontent.com/chiLL-Gekk0/Superiorly-PostInstall-Assets/main/Nvidia%20Profiles/Latency-Test-Experimental.nip", "B0580C050C689D62E21897F953980FA874D5EFAE4ABC8F6433D3F48C7E9B1BFF"),
    };

    private static readonly System.Net.Http.HttpClient NipHttp = CreateNipHttp();
    private static int _nipFetchState;
    private static System.Net.Http.HttpClient CreateNipHttp()
    {
        var h = new System.Net.Http.HttpClient { Timeout = TimeSpan.FromMinutes(2) };
        h.DefaultRequestHeaders.UserAgent.ParseAdd("Superiorly.PostInstall");
        return h;
    }

    private async Task EnsureNipsAsync()
    {
        if (System.Threading.Interlocked.CompareExchange(ref _nipFetchState, 1, 0) != 0) return;
        try
        {
            var nipDir = Path.Combine(AppContext.BaseDirectory, "Nvidia Profiles");
            try { Directory.CreateDirectory(nipDir); } catch { return; }
            using var cts = new System.Threading.CancellationTokenSource(TimeSpan.FromMinutes(2));
            foreach (var n in MirrorNips)
            {
                var dest = Path.Combine(nipDir, n.Name);
                if (File.Exists(dest)) continue;
                try
                {
                    using var cts2 = System.Threading.CancellationTokenSource.CreateLinkedTokenSource(cts.Token);
                    cts2.CancelAfter(TimeSpan.FromSeconds(30));
                    using var res = await NipHttp.GetAsync(n.Url, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cts2.Token).ConfigureAwait(false);
                    res.EnsureSuccessStatusCode();
                    var tmp = dest + ".part";
                    using (var net = await res.Content.ReadAsStreamAsync(cts2.Token).ConfigureAwait(false))
                    using (var fs = File.Create(tmp)) { await net.CopyToAsync(fs, cts2.Token).ConfigureAwait(false); }
                    using (var sha = System.Security.Cryptography.SHA256.Create())
                    using (var fh = File.OpenRead(tmp))
                    {
                        if (!Convert.ToHexString(sha.ComputeHash(fh)).Equals(n.Sha, StringComparison.OrdinalIgnoreCase)) { try { File.Delete(tmp); } catch { } continue; }
                    }
                    File.Move(tmp, dest, true);
                }
                catch { try { File.Delete(dest + ".part"); } catch { } }
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
            Options.Add(new OptionViewModel(this, new ActionOption { Label = "Downloading profiles...", Commands = new List<string>() }));
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
            var nipDest = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Superiorly", "npi", Path.GetFileName(file));
            var cmd = $"powershell -NoProfile -ExecutionPolicy Bypass -Command " +
                $"$d=[IO.Path]::GetDirectoryName('{nipDest}'); " +
                $"New-Item -ItemType Directory -Force -Path $d|Out-Null; " +
                $"Copy-Item '{file}' '{nipDest}' -Force; " +
                $"$npi=Get-ChildItem $env:TEMP -Recurse -Filter 'nvidiaProfileInspector.exe' -ErrorAction SilentlyContinue|Select-Object -First 1; " +
                $"if(-not $npi){{ $nd=$env:TEMP+'\\npiu'; if(-not(Test-Path $nd+'\\nvidiaProfileInspector.exe')){{ " +
                $"[Net.ServicePointManager]::SecurityProtocol=[Net.SecurityProtocolType]::Tls12; " +
                $"(New-Object Net.WebClient).DownloadFile('https://github.com/Orbmu2k/nvidiaProfileInspector/releases/latest/download/nvidiaProfileInspector.zip',$d+'\\npi.zip'); " +
                $"Expand-Archive -Path ($d+'\\npi.zip') -DestinationPath $nd -Force }}; " +
                $"$npi=Get-ChildItem $nd -Recurse -Filter 'nvidiaProfileInspector.exe'|Select-Object -First 1 }}; " +
                $"& $npi.FullName -silentImport '{nipDest}'";

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
        var cruDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Superiorly", "Tools", "cru");
        var tempCru = Path.Combine(Path.GetTempPath(), "cru");
        string? foundDir = Directory.Exists(cruDir) ? cruDir : Directory.Exists(tempCru) ? tempCru : null;
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
            var dlCmd = "powershell -NoProfile -ExecutionPolicy Bypass -Command " +
                "$d='" + cruDir + "'; " +
                "New-Item -ItemType Directory -Force -Path $d|Out-Null; " +
                "[Net.ServicePointManager]::SecurityProtocol=[Net.SecurityProtocolType]::Tls12; " +
                "(New-Object Net.WebClient).DownloadFile('https://www.monitortests.com/download/cru/cru-1.5.3.zip',$d+'\\cru.zip'); " +
                "Expand-Archive -Path ($d+'\\cru.zip') -DestinationPath $d -Force; " +
                "$exe=Get-ChildItem $d -Recurse -Filter 'CRU.exe'|Select-Object -First 1; " +
                "if($exe){Start-Process $exe.FullName}";
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
