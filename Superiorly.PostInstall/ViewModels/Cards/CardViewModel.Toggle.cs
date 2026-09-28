using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

public partial class CardViewModel : ObservableObject {

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
}
