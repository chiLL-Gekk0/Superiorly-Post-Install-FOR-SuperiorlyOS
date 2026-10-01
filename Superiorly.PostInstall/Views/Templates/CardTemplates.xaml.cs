using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Superiorly.PostInstall.Views.Templates;

public partial class CardTemplates : ResourceDictionary
{
    public CardTemplates() => InitializeComponent();

    private void InfoIcon_MouseEnter(object sender, MouseEventArgs e)
    {
        _infoPopupCloseTimer.Stop();
        _infoPopupCloseTimer.Tick -= InfoPopupCloseTick;
        if (_activeInfoPopup != null && _activeInfoPopup.IsOpen)
            _activeInfoPopup.IsOpen = false;
        if (sender is FrameworkElement fe)
        {
            _pendingInfoIcon = fe;
            _infoPopupShowTimer.Stop();
            _infoPopupShowTimer.Tick -= InfoPopupShowTick;
            _infoPopupShowTimer.Tick += InfoPopupShowTick;
            _infoPopupShowTimer.Start();
        }
    }

    private void InfoIcon_MouseLeave(object sender, MouseEventArgs e)
    {
        _infoPopupShowTimer.Stop();
        _infoPopupShowTimer.Tick -= InfoPopupShowTick;
        _pendingInfoIcon = null;
        _infoPopupCloseTimer.Stop();
        _infoPopupCloseTimer.Tick -= InfoPopupCloseTick;
        _infoPopupCloseTimer.Tick += InfoPopupCloseTick;
        _infoPopupCloseTimer.Start();
    }

    private readonly DispatcherTimer _infoPopupCloseTimer = new() { Interval = TimeSpan.FromMilliseconds(200) };
    private readonly DispatcherTimer _infoPopupShowTimer = new() { Interval = TimeSpan.FromMilliseconds(400) };
    private Popup? _activeInfoPopup;
    private FrameworkElement? _pendingInfoIcon;

    private void InfoPopupShowTick(object? sender, EventArgs e)
    {
        _infoPopupShowTimer.Stop();
        _infoPopupShowTimer.Tick -= InfoPopupShowTick;
        if (_pendingInfoIcon is FrameworkElement fe)
        {
            _activeInfoPopup = fe.FindName("InfoPopup") as Popup;
            if (_activeInfoPopup == null) return;
            _activeInfoPopup.PlacementTarget = fe;
            _activeInfoPopup.IsOpen = true;
            FitPopupInWindow(fe);
            try
            {
                // animate open explicitly; popupanimation alone renders instant on some systems
                if (_activeInfoPopup.Child is FrameworkElement card)
                {
                    card.RenderTransform = new TranslateTransform();
                    card.BeginAnimation(UIElement.OpacityProperty, new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(220)));
                    card.RenderTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation(-10, 0, TimeSpan.FromMilliseconds(220)) { EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut } });
                }
            }
            catch { }
        }
    }

    private void FitPopupInWindow(FrameworkElement anchor)
    {
        try
        {
            // measure after open: pre-open DesiredSize is empty, post-open ActualWidth is real
            if (_activeInfoPopup?.Child is not FrameworkElement card) return;
            var win = Window.GetWindow(anchor);
            if (win == null) return;
            card.UpdateLayout();
            var w = card.ActualWidth;
            if (w <= 0) return;
            var pos = anchor.TranslatePoint(new Point(0, 0), win);
            if (pos.X + anchor.ActualWidth + 8 + w > win.ActualWidth - 8)
            {
                _activeInfoPopup.Placement = PlacementMode.Left;
                _activeInfoPopup.HorizontalOffset = -8;
            }
            else
            {
                _activeInfoPopup.Placement = PlacementMode.Right;
                _activeInfoPopup.HorizontalOffset = 8;
            }
        }
        catch { }
    }

    private void InfoPopupCloseTick(object? sender, EventArgs e)
    {
        _infoPopupCloseTimer.Stop();
        _infoPopupCloseTimer.Tick -= InfoPopupCloseTick;
        if (_activeInfoPopup != null) _activeInfoPopup.IsOpen = false;
    }

    private void InfoPopupContent_MouseEnter(object sender, MouseEventArgs e)
    {
        _infoPopupCloseTimer.Stop();
        _infoPopupCloseTimer.Tick -= InfoPopupCloseTick;
    }

    private void InfoPopupContent_MouseLeave(object sender, MouseEventArgs e)
    {
        _infoPopupCloseTimer.Stop();
        _infoPopupCloseTimer.Tick -= InfoPopupCloseTick;
        _infoPopupCloseTimer.Tick += InfoPopupCloseTick;
        _infoPopupCloseTimer.Start();
    }
}
