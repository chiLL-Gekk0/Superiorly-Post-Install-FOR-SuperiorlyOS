using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

public partial class CardViewModel : ObservableObject {

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
        InfoText = TranslationService.HasActionInfo(_action.Id) ? TranslationService.GetActionInfo(_action.Id, lang) : "";
        ApplyCardLabels(lang);
        foreach (var option in Options) option.RefreshLanguage(lang);
        System.Windows.Data.CollectionViewSource.GetDefaultView(Items)?.Refresh();
        OnPropertyChanged(nameof(TipControversy));
        OnPropertyChanged(nameof(TipData));
        OnPropertyChanged(nameof(ShowSecurity));
        OnPropertyChanged(nameof(HasInfo));
        OnPropertyChanged(nameof(ActionButtonLabel));
    }
}
