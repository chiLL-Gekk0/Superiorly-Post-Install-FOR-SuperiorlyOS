using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

public partial class CardViewModel : ObservableObject {

    public CardViewModel(ICommandRunner runner, IDownloadCommandRunner downloadRunner, IStoreSearchService storeSearch, ActionItem action, MainViewModel owner)
    {
        _runner = runner;
        _downloadRunner = downloadRunner;
        _storeSearch = storeSearch;
        _owner = owner;
        _action = action;
        Title = TranslationService.GetActionTitle(action.Id, owner.SelectedLanguage.Code);
        Description = TranslationService.GetActionDescription(action.Id, owner.SelectedLanguage.Code);
        InfoText = TranslationService.HasActionInfo(action.Id) ? TranslationService.GetActionInfo(action.Id, owner.SelectedLanguage.Code) : "";
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
        if (_action.Id == "apply-nip") { LoadNipProfiles(); _ = EnsureNipsAsync(); }
        if (_action.Id is "radeonsoftwareslimmer" or "moreclocktool" or "morepowertool" or "radeonmod")
            LoadAmdTool();
        if (_action.Id == "cru")
            LoadCruTools();
        if (_action.Id == "powerplan-manager")
        {
            // paint from warmed cache, refresh in background
            if (_powerPlanOutputCache != null)
            {
                try { ApplyPlans(ParsePlanOutput(_powerPlanOutputCache)); } catch { }
            }
            _ = RefreshPowerPlansAsync();
        }
    }
}
