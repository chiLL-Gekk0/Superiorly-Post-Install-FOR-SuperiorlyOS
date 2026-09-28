using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

public partial class CardViewModel : ObservableObject
{
    private readonly ICommandRunner _runner;
    private readonly IDownloadCommandRunner _downloadRunner;
    private readonly IStoreSearchService _storeSearch;
    private readonly IReadOnlyList<string> _checks;
    private readonly IReadOnlyList<string> _launch;
    private readonly string _actionType;
    private readonly ActionOption? _enableOption;
    private readonly ActionOption? _disableOption;
    private readonly MainViewModel _owner;
    private readonly ActionItem _action;
    private CancellationTokenSource? _cts;
    private static List<string>? _uninstallNamesCache;
    private static DateTime _uninstallCacheExpiry;
    private static readonly object _uninstallLock = new();
    private static readonly System.Threading.SemaphoreSlim _stateSemaphore = new(3);

    // ponytail: WOW64 compat lives in Services.PowerShellHelper (shared by all launchers); path intent here.
    private static bool PreferOs64View => Services.PowerShellHelper.PreferOs64View;
    private static string PowerShellExe => Services.PowerShellHelper.ExePath;

    private static string ExpandOsPaths(string s)
    {
        // Catalog authors mean the native 64-bit dir; preserve that intent. (x86) token first: it contains the plain token as prefix.
        if (PreferOs64View)
        {
            s = s.Replace("$env:ProgramFiles(x86)", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), StringComparison.OrdinalIgnoreCase);
            var w6432 = Environment.GetEnvironmentVariable("ProgramW6432");
            if (!string.IsNullOrEmpty(w6432))
                s = s.Replace("$env:ProgramFiles", w6432, StringComparison.OrdinalIgnoreCase)
                     .Replace("%ProgramFiles%", w6432, StringComparison.OrdinalIgnoreCase);
        }
        return Environment.ExpandEnvironmentVariables(s);
    }

    private static Microsoft.Win32.RegistryKey? OpenOsView(Microsoft.Win32.RegistryKey hive, string path)
    {
        if (!PreferOs64View) return hive.OpenSubKey(path);
        var h = ReferenceEquals(hive, Microsoft.Win32.Registry.LocalMachine) ? Microsoft.Win32.RegistryHive.LocalMachine
            : ReferenceEquals(hive, Microsoft.Win32.Registry.CurrentUser) ? Microsoft.Win32.RegistryHive.CurrentUser
            : ReferenceEquals(hive, Microsoft.Win32.Registry.ClassesRoot) ? Microsoft.Win32.RegistryHive.ClassesRoot
            : ReferenceEquals(hive, Microsoft.Win32.Registry.Users) ? Microsoft.Win32.RegistryHive.Users
            : Microsoft.Win32.RegistryHive.CurrentConfig;
        return Microsoft.Win32.RegistryKey.OpenBaseKey(h, Microsoft.Win32.RegistryView.Registry64).OpenSubKey(path);
    }

    [ObservableProperty]
    private string _title = "";
    [ObservableProperty]
    private string _description = "";
    [ObservableProperty]
    private string _stateOnLabel = "On";
    [ObservableProperty]
    private string _stateOffLabel = "Off";
    [ObservableProperty]
    private string _searchLabel = "Search";
    [ObservableProperty]
    private string _installLabel = "Install";
    [ObservableProperty]
    private string _searchPlaceholder = "Search by name, URL, or ID.";
    [ObservableProperty]
    private string _noResultsLabel = "No results found. Try another search.";
    [ObservableProperty]
    private string _loadListLabel = "Load list";
    [ObservableProperty]
    private string _unloadListLabel = "Unload list";
    [ObservableProperty]
    private string _activateLabel = "Activate";
    [ObservableProperty]
    private string _importLabel = "Import";
    [ObservableProperty]
    private string _exportLabel = "Export";
    [ObservableProperty]
    private string _selectAllLabel = "Select All";
    [ObservableProperty]
    private string _unselectAllLabel = "Unselect All";
    [ObservableProperty]
    private string _deleteLabel = "Delete";
    [ObservableProperty]
    private string _restoreDefaultLabel = "Restore Default";
    [ObservableProperty]
    private string _applyLabel = "Apply";
    [ObservableProperty]
    private string _openQuantumLabel = "Open Quantum Map";
    [ObservableProperty]
    private string _currentWin32Label = "Current Win32PrioritySeparation";
    [ObservableProperty]
    private string _modifyQuantumLabel = "Modify Quantum";
    [ObservableProperty]
    private string _quantumLengthLabel = "Quantum Length";
    [ObservableProperty]
    private string _quantumIntervalLabel = "Quantum Interval";
    [ObservableProperty]
    private string _variableLabel = "Variable";
    [ObservableProperty]
    private string _fixLabel = "Fix";
    [ObservableProperty]
    private string _shortLabel = "Short";
    [ObservableProperty]
    private string _longLabel = "Long";
    [ObservableProperty]
    private string _previewHexLabel = "Preview Hex";
    [ObservableProperty]
    private string _previewBitsLabel = "Preview Bits";
    [ObservableProperty]
    private string _securityLabel = "Security: ";

    private void ApplyCardLabels(string lang)
    {
        SearchLabel = TranslationService.GetUi("search", lang);
        InstallLabel = TranslationService.GetUi("install", lang);
        SearchPlaceholder = TranslationService.GetUi("search_placeholder", lang);
        NoResultsLabel = TranslationService.GetUi("store_no_results", lang);
        LoadListLabel = TranslationService.GetUi("load_list", lang);
        UnloadListLabel = TranslationService.GetUi("unload_list", lang);
        ActivateLabel = TranslationService.GetUi("activate", lang);
        ImportLabel = TranslationService.GetUi("import", lang);
        ExportLabel = TranslationService.GetUi("export", lang);
        SelectAllLabel = TranslationService.GetUi("select_all", lang);
        UnselectAllLabel = TranslationService.GetUi("unselect_all", lang);
        DeleteLabel = TranslationService.GetUi("delete", lang);
        RestoreDefaultLabel = TranslationService.GetUi("restore_default", lang);
        ApplyLabel = TranslationService.GetUi("apply", lang);
        OpenQuantumLabel = TranslationService.GetUi("open_quantum", lang);
        CurrentWin32Label = TranslationService.GetUi("current_win32", lang);
        StateOnLabel = TranslationService.GetUi("state_on", lang);
        StateOffLabel = TranslationService.GetUi("state_off", lang);
        ModifyQuantumLabel = TranslationService.GetUi("modify_quantum", lang);
        QuantumLengthLabel = TranslationService.GetUi("quantum_length", lang);
        QuantumIntervalLabel = TranslationService.GetUi("quantum_interval", lang);
        VariableLabel = TranslationService.GetUi("variable", lang);
        FixLabel = TranslationService.GetUi("fix", lang);
        ShortLabel = TranslationService.GetUi("short", lang);
        LongLabel = TranslationService.GetUi("long", lang);
        PreviewHexLabel = TranslationService.GetUi("preview_hex", lang);
        PreviewBitsLabel = TranslationService.GetUi("preview_bits", lang);
        SecurityLabel = TranslationService.GetUi("security", lang);
    }

    public string Icon { get; }
    public string Logo { get; }
    public bool HasLogo => !string.IsNullOrEmpty(Logo);
    public ObservableCollection<OptionViewModel> Options { get; }

    public void RefreshLanguage(string lang)
    {
        lang = TranslationService.Normalize(lang);
        Title = TranslationService.GetActionTitle(_action.Id, lang);
        Description = TranslationService.GetActionDescription(_action.Id, lang);
        InfoText = string.IsNullOrWhiteSpace(_action.Info) ? "" : TranslationService.GetActionInfo(_action.Id, lang);
        ApplyCardLabels(lang);
        foreach (var option in Options) option.RefreshLanguage(lang);
        System.Windows.Data.CollectionViewSource.GetDefaultView(Items)?.Refresh();
        OnPropertyChanged(nameof(TipControversy));
        OnPropertyChanged(nameof(TipData));
        OnPropertyChanged(nameof(ShowSecurity));
        OnPropertyChanged(nameof(HasInfo));
        OnPropertyChanged(nameof(ActionButtonLabel));
    }

    private string Lang => _owner.SelectedLanguage.Code;

    public string SelectedLanguageCode => _owner.SelectedLanguage.Code;

    public bool HasToggle => _enableOption != null && _disableOption != null;
    public bool IsCombo => !HasToggle && Options.Count > 1;
    public bool IsPresetCombo => IsCombo && !IsDownloadCard;
    private static readonly System.Collections.Generic.HashSet<string> DestructiveIds = new() { "smb2", "system-restore", "modern-standby" };
    private static readonly System.Collections.Generic.HashSet<string> ConfirmIds = new() { "brave-debloat", "edge-debloat", "chrome-debloat", "firefox-debloat", "office-debloat", "nvidia-telemetry" };
    public bool IsDestructive => DestructiveIds.Contains(_action.Id);
    public bool IsSearchCard => _action.Type == "search";
    public string ActionId => _action.Id;
    public bool IsListCard => _action.Type == "list";
    public bool IsWin32Card => _action.Id == "win32priorityseparation";
    public bool IsPowerPlanCard => _action.Id == "powerplan-manager";
    public CardViewModel? CpuIdleCard => _owner.GetCardById("cpu-idle");
    public bool IsGroupHeader => _action.Type == "group-header";
    public bool HideGroupHeader { get; set; }

    [ObservableProperty]
    private string _groupTitle = "";
    [ObservableProperty]
    private string _groupDescription = "";

    public bool HasTip => _action.Tip != null;
    public bool IsDownloadCard => _actionType == "download";
    public bool HasInfo => !string.IsNullOrEmpty(InfoText) || _action.Tip != null;
    [ObservableProperty]
    private string _infoText = "";
    public string TipControversy => TipText(_action.Tip?.Controversy);
    public string TipData => TipText(_action.Tip?.Data);
    public int TipSecurity => _action.Tip?.Security ?? 0;
    public string TipSecurityText => $"{TipSecurity}/10";
    // ponytail: debloat policies are not a security score — hide the ranking there only
    public bool ShowSecurity => HasTip && TipSecurity > 0 && ActionId is not "brave-debloat" and not "edge-debloat";

    public bool HasSearchResults => StoreResults.Count > 0;

    [ObservableProperty]
    private bool _isSearching;

    public ObservableCollection<StoreResultItem> StoreResults { get; } = new();

    public IRelayCommand InstallSelectedCommand { get; }

    private string TipText(Dictionary<string, string>? map) =>
        map is null ? "" :
        map.TryGetValue(_owner.SelectedLanguage.Code, out var v) ? v :
        map.GetValueOrDefault("en", "");

    [ObservableProperty]
    private string _win32CurrentHex = "0x02";
    [ObservableProperty]
    private string _win32CurrentBinary = "000010";
    [ObservableProperty]
    private string _win32CurrentPs = "3:1";
    [ObservableProperty]
    private string _win32CurrentQuantum = "Variable · Short · 3:1";
    [ObservableProperty]
    private string _win32SelectedPs = "1:1";
    [ObservableProperty]
    private bool _win32LengthFixed;
    [ObservableProperty]
    private bool _win32IntervalLong;

    [ObservableProperty]
    private string _win32PreviewHex = "0x28";
    [ObservableProperty]
    private string _win32PreviewBinary = "101000";

    [ObservableProperty]
    private OptionViewModel? _selectedOption;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsBusy))]
    private bool _running;

    public bool IsBusy => Running;

    public bool IsInstalling { get; private set; }

    [ObservableProperty]
    private bool _isOn;

    [ObservableProperty]
    private bool _isChecking;

    public bool IsInstalled => IsOn && _actionType == "download";
    public string ActionButtonLabel => IsChecking ? "..." : IsBusy ? string.Format(TranslationService.GetUi(IsOn ? "starting" : "downloading", Lang), Title) : IsCombo ? TranslationService.GetUi("apply", Lang) : (_checks.Count > 0 ? (IsOn ? TranslationService.GetUi("apply", Lang) : TranslationService.GetUi("download", Lang)) : IsDownloadCard ? (IsInstalled ? TranslationService.GetUi("apply", Lang) : TranslationService.GetUi("download", Lang)) : (Options.Count > 0 ? Options[0].Label : TranslationService.GetUi("apply", Lang)));

    partial void OnIsOnChanged(bool value) { OnPropertyChanged(nameof(IsInstalled)); OnPropertyChanged(nameof(ActionButtonLabel)); }
    partial void OnIsCheckingChanged(bool value) { OnPropertyChanged(nameof(ActionButtonLabel)); }

    [ObservableProperty]
    private bool _searchExecuted;

    public bool HasNoSearchResults => SearchExecuted && !IsSearching && StoreResults.Count == 0;

    // ponytail: skeleton only when there is nothing to show yet
    public bool ShowSkeletons => IsSearching && StoreResults.Count == 0;

    partial void OnIsSearchingChanged(bool value) { OnPropertyChanged(nameof(HasSearchResults)); OnPropertyChanged(nameof(HasNoSearchResults)); OnPropertyChanged(nameof(ShowSkeletons)); }
    partial void OnSearchExecutedChanged(bool value) { OnPropertyChanged(nameof(HasNoSearchResults)); OnPropertyChanged(nameof(ShowSkeletons)); }

    [ObservableProperty]
    private string _userInput = "";

    public RangeObservableCollection<object> Items { get; } = new();

    public bool HasItems => Items.Count > 0;

    public bool HasCheckedItems => Items.OfType<PowerPlanItem>().Any(i => i.IsChecked);
    public bool HasCheckedCustomItems => Items.OfType<PowerPlanItem>().Any(i => i.IsChecked && !i.IsOfficial);
    public int CheckedCount => Items.OfType<PowerPlanItem>().Count(i => i.IsChecked);


    public IAsyncRelayCommand ToggleCommand { get; }
    public IAsyncRelayCommand ApplyCommand { get; }
    public IAsyncRelayCommand LoadItemsCommand { get; }
    public IRelayCommand UnselectAllCommand { get; }
    public IRelayCommand SelectAllCommand { get; }
    public IRelayCommand ClearSearchCommand { get; }
    public IRelayCommand ResearchCommand { get; }
    public IAsyncRelayCommand Win32ApplyCommand { get; }
    public IRelayCommand Win32RestoreDefaultCommand { get; }
    public IRelayCommand Win32OpenMapCommand { get; }
    public IAsyncRelayCommand ActivatePowerPlanCommand { get; }
    public IAsyncRelayCommand DeletePowerPlanCommand { get; }
    public IAsyncRelayCommand ImportPowerPlanCommand { get; }
    public IAsyncRelayCommand ExportPowerPlanCommand { get; }

    public CardViewModel(ICommandRunner runner, IDownloadCommandRunner downloadRunner, IStoreSearchService storeSearch, ActionItem action, MainViewModel owner)
    {
        _runner = runner;
        _downloadRunner = downloadRunner;
        _storeSearch = storeSearch;
        _owner = owner;
        _action = action;
        Title = TranslationService.GetActionTitle(action.Id, owner.SelectedLanguage.Code);
        Description = TranslationService.GetActionDescription(action.Id, owner.SelectedLanguage.Code);
        InfoText = string.IsNullOrWhiteSpace(action.Info) ? "" : TranslationService.GetActionInfo(action.Id, owner.SelectedLanguage.Code);
        ApplyCardLabels(owner.SelectedLanguage.Code);
        Icon = action.Icon;
        Logo = action.Logo;
        _checks = action.Check;
        _launch = action.Launch;
        _actionType = action.Type;

        _enableOption = FindOption(action, "enable");
        _disableOption = FindOption(action, "disable");

        var otherOptions = action.Options
            .Where(o => !ReferenceEquals(o, _enableOption) && !ReferenceEquals(o, _disableOption))
            .Select(o => new OptionViewModel(this, o));
        Options = new ObservableCollection<OptionViewModel>(otherOptions);

        ToggleCommand = new AsyncRelayCommand(ToggleAsync, () => !IsBusy);
        ApplyCommand = new AsyncRelayCommand(
            () => RunAsync(SelectedOption!.Option),
            () => !IsBusy && SelectedOption != null && SelectedOption.Option.Commands.Count > 0);
        LoadItemsCommand = new AsyncRelayCommand(() => LoadItemsAsync(), () => !IsBusy);
        UnselectAllCommand = new RelayCommand(() => { foreach (var it in Items.OfType<PowerPlanItem>()) it.IsChecked = false; }, () => HasCheckedItems);
        SelectAllCommand = new RelayCommand(() => { foreach (var it in Items.OfType<PowerPlanItem>()) it.IsChecked = true; }, () => Items.OfType<PowerPlanItem>().Any(i => !i.IsChecked));
        ClearSearchCommand = new RelayCommand(() => { UserInput = ""; });
        ResearchCommand = new RelayCommand(() => { if (IsSearchCard && Options.Count > 0) _ = RunAsync(Options[0].Option); });
        InstallSelectedCommand = new AsyncRelayCommand(InstallSelectedAsync, () => !IsInstalling && StoreResults.Any(r => r.IsSelected));
        Win32ApplyCommand = new AsyncRelayCommand(Win32ApplyAsync, () => !IsBusy);
        Win32RestoreDefaultCommand = new RelayCommand(Win32RestoreDefault);
        Win32OpenMapCommand = new RelayCommand(OpenQuantumMap);
        ActivatePowerPlanCommand = new AsyncRelayCommand(ActivatePowerPlanAsync, () => !IsBusy && CheckedCount == 1);
        DeletePowerPlanCommand = new AsyncRelayCommand(DeletePowerPlanAsync, () => !IsBusy && HasCheckedCustomItems);
        ImportPowerPlanCommand = new AsyncRelayCommand(ImportPowerPlanAsync, () => !IsBusy);
        ExportPowerPlanCommand = new AsyncRelayCommand(ExportPowerPlanAsync, () => !IsBusy && HasCheckedItems);

        SelectedOption = Options.FirstOrDefault();
        if (IsCombo && _action.Id is "hop-limit" or "nx-mode" or "fivem-safe-services")
            TryDetectComboSelection();
        var subscribed = new HashSet<object>();
        void Track(object it)
        {
            if (!subscribed.Add(it)) return;
            if (it is PowerPlanItem pItem) pItem.PropertyChanged += OnItemPropertyChanged;
        }
        void Untrack(object it)
        {
            if (!subscribed.Remove(it)) return;
            if (it is PowerPlanItem pItem) pItem.PropertyChanged -= OnItemPropertyChanged;
        }
        Items.CollectionChanged += (s, e) =>
        {
            DeletePowerPlanCommand.NotifyCanExecuteChanged();
            UnselectAllCommand.NotifyCanExecuteChanged();
            OnPropertyChanged(nameof(HasItems));
            OnPropertyChanged(nameof(HasCheckedItems));
            OnPropertyChanged(nameof(HasCheckedCustomItems));
            OnPropertyChanged(nameof(CheckedCount));
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Reset)
            {
                foreach (var it in subscribed.ToList()) Untrack(it);
                foreach (object it in Items) Track(it);
                return;
            }
            if (e.NewItems != null) foreach (object it in e.NewItems) Track(it);
            if (e.OldItems != null) foreach (object it in e.OldItems) Untrack(it);
        };
        StoreResults.CollectionChanged += (s, e) =>
        {
            OnPropertyChanged(nameof(HasSearchResults));
            OnPropertyChanged(nameof(HasNoSearchResults));
            OnPropertyChanged(nameof(ShowSkeletons));
            InstallSelectedCommand.NotifyCanExecuteChanged();
            if (e.NewItems != null) foreach (StoreResultItem it in e.NewItems) it.PropertyChanged += (s2, e2) => { if (e2.PropertyName == "IsSelected") InstallSelectedCommand.NotifyCanExecuteChanged(); };
        };
        if (IsWin32Card)
        {
            Win32Refresh();
            UpdateWin32Preview();
        }
        if (_action.Id == "apply-nip") { LoadNipProfiles(); EnsureLocalNips(); }
        if (_action.Id is "radeonsoftwareslimmer" or "moreclocktool" or "morepowertool" or "radeonmod")
            LoadAmdTool();
        if (_action.Id == "cru")
            LoadCruTools();
        if (_action.Id == "powerplan-manager")
        {
            // ponytail: paint instantly from startup-warmed cache, refresh in background
            if (_powerPlanOutputCache != null)
            {
                try { ApplyPlans(ParsePlanOutput(_powerPlanOutputCache)); } catch { }
            }
            _ = RefreshPowerPlansAsync();
        }
    }

    // ponytail: EXPERIMENTAL nips ship in the bundle (Nvidia Profiles), SHA256-checked below
    private static readonly (string Name, string Sha)[] BundledNips =
    {
        ("EXPERIMENTAL-LLM-ON-RENDERS-DEF.nip", "AD79219730A3364C2DE37824E16FA5766F88A3FDDFEE148BCACED2D89814D329"),
        ("EXPERIMENTAL-LLM-ON-RENDERS-DEF-V2.nip", "897B733242FB9160C6224B8D6B036D3CC27F37A3F1B90367A42EB5119F312274"),
        ("EXPERIMENTAL-LLM-ON-RENDERS-DEF-PREFETCH+RTCORE-V2.nip", "B48F3DB395E0E6758D9B4487360CD7FC65862443E07695B67824A587B3C31BD2"),
        ("EXPERIMENTAL-AGGRESSIVE-TEST.nip", "AA149815190F3B0E17B4B899AC6C1D90C7BB51CA03424B4E07BECCBC337A4A07"),
        ("Global-Test-Experimental.nip", "1E1147EF1A36FA231F67BC098981E8A659066E02BC1EA496E1627B851D65CE02"),
        ("Latency-Test-Experimental.nip", "B0580C050C689D62E21897F953980FA874D5EFAE4ABC8F6433D3F48C7E9B1BFF"),
    };

    // ponytail: bundled profiles only — no downloads; a hash mismatch means a broken install
    private void EnsureLocalNips()
    {
        try
        {
            var nipDir = Path.Combine(AppContext.BaseDirectory, "Nvidia Profiles");
            if (!Directory.Exists(nipDir)) return;
            using var sha = System.Security.Cryptography.SHA256.Create();
            foreach (var n in BundledNips)
            {
                var p = Path.Combine(nipDir, n.Name);
                if (!File.Exists(p)) continue;
                try
                {
                    using var fh = File.OpenRead(p);
                    if (!Convert.ToHexString(sha.ComputeHash(fh)).Equals(n.Sha, StringComparison.OrdinalIgnoreCase))
                        _owner.Notify(n.Name + ": SHA256 mismatch, reinstall the app", null, Title, char.ConvertFromUtf32(0xE711));
                }
                catch { }
            }
        }
        catch { }
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

    private async Task ToggleAsync()
    {
        if (!HasToggle) return;
        var wantOn = IsOn;
        if (wantOn && ConfirmIds.Contains(_action.Id) &&
            !await _owner.ShowConfirmAsync(TranslationService.GetUi("confirm_enable", Lang), Title))
        {
            IsOn = false;
            return;
        }
        var target = wantOn ? _enableOption : _disableOption;
        await RunAsync(target!);
        await RefreshStateAsync();
        if (IsOn != wantOn) _owner.Notify(Title + ": " + TranslationService.GetUi("failed_admin", Lang), null, Title, char.ConvertFromUtf32(0xE711));
    }

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

    partial void OnWin32SelectedPsChanged(string value) => UpdateWin32Preview();
    partial void OnWin32LengthFixedChanged(bool value) => UpdateWin32Preview();
    partial void OnWin32IntervalLongChanged(bool value) => UpdateWin32Preview();

    private void Win32Refresh()
    {
        try
        {
            using var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\PriorityControl");
            object? raw = key?.GetValue("Win32PrioritySeparation");
            int val = 2;
            if (raw is int ii) val = ii;
            else if (raw is byte bb) val = bb;
            else if (raw is uint uu) val = (int)uu;
            else if (raw is long ll) val = (int)ll;
            Win32CurrentHex = $"0x{val:X2}";
            Win32CurrentBinary = Convert.ToString(val, 2).PadLeft(6, '0');
            int boost = val & 0x3;
            bool isFixed = (val & 0x4) != 0;
            bool isLong = (val & 0x8) != 0;
            Win32CurrentPs = boost == 0 ? "1:1" : boost == 1 ? "2:1" : "3:1";
            Win32CurrentQuantum = $"{TranslationService.GetUi(isFixed ? "fixed" : "variable", Lang)} · {TranslationService.GetUi(isLong ? "long" : "short", Lang)} · {Win32CurrentPs}";
        }
        catch { }
    }

    private void UpdateWin32Preview()
    {
        int boost = Win32SelectedPs == "2:1" ? 1 : Win32SelectedPs == "3:1" ? 2 : 0;
        int type = Win32LengthFixed ? 1 : 0;
        int length = Win32IntervalLong ? 1 : 0;
        int psMap = Win32SelectedPs == "1:1" ? 2 : Win32SelectedPs == "2:1" ? 1 : 0;
        int val = (psMap << 4) | (length << 3) | (type << 2) | boost;
        Win32PreviewHex = $"0x{val:X2}";
        Win32PreviewBinary = Convert.ToString(val, 2).PadLeft(6, '0');
    }

    private async Task Win32ApplyAsync()
    {
        if (Running) return;
        Running = true;
        try
        {
            var hex = Win32PreviewHex;
            int dec = Convert.ToInt32(hex.Replace("0x",""), 16);
            var cmd = $"reg add \"HKLM\\SYSTEM\\CurrentControlSet\\Control\\PriorityControl\" /v Win32PrioritySeparation /t REG_DWORD /d {dec} /f";
            var ok = await Task.Run(() => _runner.RunAll(new[] { cmd }));
            _owner.Notify(ok ? string.Format(TranslationService.GetUi("win32_set", Lang), hex) : TranslationService.GetUi("failed", Lang), null, Title, ok ? char.ConvertFromUtf32(0xE73E) : char.ConvertFromUtf32(0xE711));
            Win32Refresh();
        }
        finally { Running = false; }
    }

    private void Win32RestoreDefault()
    {
        Win32SelectedPs = "2:1";
        Win32LengthFixed = false;
        Win32IntervalLong = false;
        UpdateWin32Preview();
    }

    internal async Task RunAsync(ActionOption option)
    {
        if (option.Commands.Count == 0) return;
        // ponytail: search re-entry cancels the previous search instead of staying dead on IsBusy
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

    private async Task InstallSelectedAsync()
    {
        var selected = StoreResults.Where(r => r.IsSelected).ToList();
        if (selected.Count == 0) return;
        IsInstalling = true;
        Running = true;
        InstallSelectedCommand.NotifyCanExecuteChanged();
        using var cts = new CancellationTokenSource();
        try
        {
            var allOk = true;
            foreach (var item in selected)
            {
                _owner.ShowProgress(Title, string.Format(TranslationService.GetUi("installing", Lang), item.Name));
                var progress = new Progress<int>(pct => _owner.UpdateProgress(pct));
                var src = item.Source == "msstore" ? " -s msstore" : "";
                var commands = new[] { $"winget install --id {item.PackageId} -e{src} --silent --accept-package-agreements --accept-source-agreements" };
                allOk = await _downloadRunner.RunAllAsync(commands, progress, cts.Token) && allOk;
            }
            _owner.Notify(allOk ? string.Format(TranslationService.GetUi("installed_n", Lang), selected.Count) : Title + ": " + TranslationService.GetUi("install_failed", Lang), null, Title, char.ConvertFromUtf32(0xE719));
        }
        finally
        {
            _owner.HideProgress();
            Running = false;
            IsInstalling = false;
            InstallSelectedCommand.NotifyCanExecuteChanged();
        }
    }

}

public partial class OptionViewModel : ObservableObject
{
    private readonly CardViewModel _owner;
    private readonly string _sourceLabel;

    [ObservableProperty]
    private string _label = "";
    internal ActionOption Option { get; }
    public IRelayCommand RunCommand { get; }

    public OptionViewModel(CardViewModel owner, ActionOption option)
    {
        _owner = owner;
        _sourceLabel = option.Label;
        _label = TranslationService.GetOptionLabel(option.Label, owner.SelectedLanguageCode);
        Option = option;

        RunCommand = new AsyncRelayCommand(
            () => _owner.RunAsync(option),
            () => !_owner.IsBusy && option.Commands.Count > 0);
    }

    public void RefreshLanguage(string lang) =>
        Label = TranslationService.GetOptionLabel(_sourceLabel, lang);
}

public partial class StoreResultItem : ObservableObject
{
    [ObservableProperty]
    private string _name = "";

    [ObservableProperty]
    private string _packageId = "";

    [ObservableProperty]
    private string _publisher = "";

    [ObservableProperty]
    private bool _isSelected;

    public string Source { get; set; } = "msstore";
}

public partial class PowerPlanItem : ObservableObject
{
    [ObservableProperty]
    private string _guid = "";

    [ObservableProperty]
    private string _name = "";

    [ObservableProperty]
    private bool _isActive;

    [ObservableProperty]
    private bool _isChecked;

    [ObservableProperty]
    private bool _isOfficial;

    [ObservableProperty]
    private string _groupName = "";

    public string DisplayName => Name;
    public string Detail => Guid;
}
