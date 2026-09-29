using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Superiorly.PostInstall.ViewModels;

namespace Superiorly.PostInstall.Views.Dialogs;

public partial class SettingsDialog : UserControl
{
    public SettingsDialog() => InitializeComponent();

    private void SettingsOverlay_Click(object sender, MouseButtonEventArgs e)
    {
        if (sender is Grid grid && e.OriginalSource == grid)
            ((MainViewModel)DataContext).HideSettingsDialogCommand.Execute(null);
    }
}
