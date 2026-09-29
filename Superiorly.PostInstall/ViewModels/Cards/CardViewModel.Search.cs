using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

public partial class CardViewModel : ObservableObject {

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
}
