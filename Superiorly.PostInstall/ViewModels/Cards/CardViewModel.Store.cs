using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Superiorly.PostInstall.Models;
using Superiorly.PostInstall.Services;

namespace Superiorly.PostInstall.ViewModels;

public partial class CardViewModel : ObservableObject {

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
