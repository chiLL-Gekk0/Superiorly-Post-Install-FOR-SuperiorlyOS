using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Superiorly.PostInstall.Services;
using Superiorly.PostInstall.ViewModels;

namespace Superiorly.PostInstall.Views;

public partial class MainWindow : Window
{
    private void OnDismissingNotification(Models.NotificationItem item)
    {
        // exit animation in code, xaml enter actions never fire here
        if (DataContext is not MainViewModel vm) return;
        try
        {
            FrameworkElement? toast = NotificationsControl.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
            if (toast != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(toast); i++)
                    if (VisualTreeHelper.GetChild(toast, i) is Border b) { toast = b; break; }
            }
            if (toast == null) { vm.ForceRemoveNotification(item); return; }
            if (toast.RenderTransform is not TranslateTransform) toast.RenderTransform = new TranslateTransform();
            var sb = new Storyboard();
            var fade = new DoubleAnimation { To = 0, Duration = new Duration(TimeSpan.FromMilliseconds(200)) };
            Storyboard.SetTarget(fade, toast);
            Storyboard.SetTargetProperty(fade, new PropertyPath("Opacity"));
            var slide = new DoubleAnimation { To = 48, Duration = new Duration(TimeSpan.FromMilliseconds(200)), EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseIn } };
            Storyboard.SetTarget(slide, toast);
            Storyboard.SetTargetProperty(slide, new PropertyPath("RenderTransform.(TranslateTransform.X)"));
            sb.Children.Add(fade);
            sb.Children.Add(slide);
            sb.Completed += (_, _) => vm.ForceRemoveNotification(item);
            sb.Begin();
        }
        catch { vm.ForceRemoveNotification(item); }
    }

    private void ApplyCardsClip(Size size)
    {
        try
        {
            // clip follows the theme radius so rounded bands keep round corners
            var r = FindResource("R_M") is CornerRadius cr ? cr.TopLeft : 0;
            CardsClipGrid.Clip = new RectangleGeometry(new Rect(0, 0, size.Width, size.Height), r, r);
        }
        catch { }
    }

    private bool _autoScrolling;
    private readonly Dictionary<string, double> _scrollMemory = new();
    private bool _restoreScrollArmed;
    private bool _suppressScrollSave;
    private System.Windows.Point _autoAnchor;
    private double _autoVelocity;
    private readonly DispatcherTimer _autoScrollTimer = new() { Interval = TimeSpan.FromMilliseconds(15) };
    private const double AutoScrollDeadZone = 15;
    // px per 15ms tick; Chromium/Windows curve: tiny drags crawl, long drags fly
    private static double AutoScrollSpeed(double pixels) => 0.000008 * Math.Pow(pixels, 2.2) * 15;

    private void StartAutoScroll(MouseButtonEventArgs e)
    {
        if (_autoScrolling) { StopAutoScroll(); return; }
        _autoScrolling = true;
        _autoAnchor = e.GetPosition(CardsSurface);
        CardsSurface.CaptureMouse();
        CardsSurface.Cursor = Cursors.ScrollAll;
        CardsSurface.MouseMove += AutoScrollMove;
        _autoScrollTimer.Tick += AutoScrollTick;
        _autoScrollTimer.Start();
        e.Handled = true;
    }

    private void AutoScrollMove(object sender, MouseEventArgs e)
    {
        var delta = e.GetPosition(CardsSurface).Y - _autoAnchor.Y;
        _autoVelocity = Math.Abs(delta) <= AutoScrollDeadZone ? 0
            : Math.Sign(delta) * AutoScrollSpeed(Math.Abs(delta) - AutoScrollDeadZone);
        CardsSurface.Cursor = _autoVelocity < 0 ? Cursors.ScrollN
            : _autoVelocity > 0 ? Cursors.ScrollS : Cursors.ScrollAll;
    }

    private void AutoScrollTick(object? sender, EventArgs e)
    {
        if (_autoVelocity != 0)
            CardsScroll.ScrollToVerticalOffset(CardsScroll.VerticalOffset + _autoVelocity);
    }


    private void StopAutoScroll()
    {
        if (!_autoScrolling) return;
        _autoScrolling = false;
        _autoVelocity = 0;
        _autoScrollTimer.Stop();
        _autoScrollTimer.Tick -= AutoScrollTick;
        CardsSurface.MouseMove -= AutoScrollMove;
        if (CardsSurface.IsMouseCaptured) CardsSurface.ReleaseMouseCapture();
        CardsSurface.Cursor = Cursors.Arrow;
    }
}
