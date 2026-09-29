using System.Windows;
using System.Windows.Controls;

namespace Superiorly.PostInstall.Views.Controls;

public partial class TitleBarControl : UserControl
{
    public TitleBarControl() => InitializeComponent();

    private void OnMinimizeClick(object sender, RoutedEventArgs e)
    {
        if (Window.GetWindow(this) is Window w) w.WindowState = WindowState.Minimized;
    }

    private void OnMaximizeClick(object sender, RoutedEventArgs e)
    {
        if (Window.GetWindow(this) is Window w) w.WindowState = w.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
    }

    private void OnCloseClick(object sender, RoutedEventArgs e) => Window.GetWindow(this)?.Close();
}
