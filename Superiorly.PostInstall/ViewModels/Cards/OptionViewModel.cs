using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

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
