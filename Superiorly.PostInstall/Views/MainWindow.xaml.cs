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
    private readonly ISettingsService _settings;

    public MainWindow(MainViewModel viewModel, ISettingsService settings)
    {
        InitializeComponent();
        DataContext = viewModel;
        _settings = settings;

        var s = settings.Load();
        if (s.WindowLeft.HasValue && s.WindowTop.HasValue)
        {
            double l = s.WindowLeft.Value, t = s.WindowTop.Value;
            var vsW = SystemParameters.VirtualScreenWidth; var vsH = SystemParameters.VirtualScreenHeight;
            bool onScreen = l >= SystemParameters.VirtualScreenLeft - 100 && l < SystemParameters.VirtualScreenLeft + vsW + 100 && t >= SystemParameters.VirtualScreenTop - 100 && t < SystemParameters.VirtualScreenTop + vsH + 100;
            if (onScreen) { Left = l; Top = t; }
            else { Left = 100; Top = 80; }
        }
        Width = Math.Max(s.WindowWidth, 640);
        Height = Math.Max(s.WindowHeight, 480);
        if (s.WindowMaximized) WindowState = WindowState.Maximized;

        SourceInitialized += OnSourceInitialized;
        Closing += OnClosing;
        viewModel.CornerStyleChanged += TryRoundCorners;
        viewModel.CornerStyleChanged += () => ApplyCardsClip(new Size(CardsClipGrid.ActualWidth, CardsClipGrid.ActualHeight));
        viewModel.DismissingNotification += OnDismissingNotification;

        CardsClipGrid.SizeChanged += (_, e) => ApplyCardsClip(e.NewSize);



        // ponytail: per-section scroll memory — save on scroll, restore once after refill
        string ScrollKey() => ((DataContext as MainViewModel)?.SelectedSection?.Id ?? "") + "/" + ((DataContext as MainViewModel)?.SelectedTab?.Id ?? "");
        CardsScroll.ScrollChanged += (_, _) =>
        {
            // ponytail: programmatic scrolls must not overwrite memory (see restore below)
            if (_suppressScrollSave) return;
            try { _scrollMemory[ScrollKey()] = CardsScroll.VerticalOffset; } catch { }
        };
        // ponytail: scrollbar visible only while actively scrolling, fade out after 1s idle
        _scrollbarIdle.Tick += (_, _) => { _scrollbarIdle.Stop(); var b = CardsBar(); if (b != null && b.IsMouseOver) { _scrollbarIdle.Start(); return; } FadeCardsBar(0, 350, false); };
        CardsScroll.ScrollChanged += (_, e) => { if (e.VerticalChange != 0) { FadeCardsBar(1, 200, true); _scrollbarIdle.Stop(); _scrollbarIdle.Start(); } };
        CardsScroll.Loaded += (_, _) => HookCardsBar();
        if (DataContext is MainViewModel vm)
        {
            vm.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(MainViewModel.SelectedSection) || e.PropertyName == nameof(MainViewModel.SelectedTab))
                    _restoreScrollArmed = true;
            };
            vm.Cards.CollectionChanged += (_, _) =>
            {
                if (!_restoreScrollArmed) return;
                _restoreScrollArmed = false;
                try
                {
                    // ponytail: restore-first single decision point — saved offset wins, else top.
                    // No zeroing in the arm above: its synchronous ScrollChanged would erase the NEW key's offset.
                    var off = _scrollMemory.TryGetValue(ScrollKey(), out var o) ? o : 0;
                    Dispatcher.BeginInvoke(() =>
                    {
                        _suppressScrollSave = true;
                        try { CardsScroll.ScrollToVerticalOffset(off > 0 ? off : 0); }
                        finally { _suppressScrollSave = false; }
                    }, DispatcherPriority.Background);
                }
                catch { }
            };
        }
        CardsSurface.PreviewMouseDown += (s, e) => { if (e.ChangedButton == MouseButton.Middle) StartAutoScroll(e); };
        CardsSurface.PreviewMouseLeftButtonDown += (_, _) => StopAutoScroll();
        CardsSurface.PreviewMouseRightButtonDown += (_, _) => StopAutoScroll();
        CardsSurface.MouseWheel += (_, _) => StopAutoScroll();
        CardsSurface.LostMouseCapture += (_, _) => StopAutoScroll();
        PreviewKeyDown += (_, e) => { if (e.Key == Key.Escape) StopAutoScroll(); };
    }

    private ScrollBar? CardsBar() => CardsScroll.Template.FindName("PART_VerticalScrollBar", CardsScroll) as ScrollBar;

    private void HookCardsBar()
    {
        if (CardsBar() is not ScrollBar bar) return;
        bar.MouseEnter += (_, _) => { _scrollbarIdle.Stop(); FadeCardsBar(1, 200, true); _scrollbarIdle.Start(); };
        bar.MouseLeave += (_, _) => { _scrollbarIdle.Stop(); _scrollbarIdle.Start(); };
    }

    private void FadeCardsBar(double to, int ms, bool hitTest)
    {
        if (CardsBar() is not ScrollBar bar) return;
        bar.IsHitTestVisible = hitTest;
        bar.BeginAnimation(UIElement.OpacityProperty, new DoubleAnimation(to, TimeSpan.FromMilliseconds(ms)));
    }

    private void OnDismissingNotification(Models.NotificationItem item)
    {
        // ponytail: exit animation runs in code (XAML EnterActions never fires here — verified headless)
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
            // ponytail: clip follows the theme radius so rounded bands keep round corners
            var r = FindResource("R_M") is CornerRadius cr ? cr.TopLeft : 0;
            CardsClipGrid.Clip = new RectangleGeometry(new Rect(0, 0, size.Width, size.Height), r, r);
        }
        catch { }
    }

    private void OnClosing(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        try
        {
            var s = _settings.Load();
            if (WindowState == WindowState.Maximized)
            {
                s.WindowMaximized = true;
                s.WindowLeft = RestoreBounds.Left;
                s.WindowTop = RestoreBounds.Top;
                s.WindowWidth = Math.Max(RestoreBounds.Width, 640);
                s.WindowHeight = Math.Max(RestoreBounds.Height, 480);
            }
            else
            {
                s.WindowMaximized = false;
                s.WindowLeft = Left;
                s.WindowTop = Top;
                s.WindowWidth = Math.Max(Width, 640);
                s.WindowHeight = Math.Max(Height, 480);
            }
            _settings.Save(s);
        }
        catch { }
    }

    private void OnSourceInitialized(object? sender, EventArgs e)
    {
        ((HwndSource)PresentationSource.FromVisual(this)!).AddHook(WndProc);
        TryRoundCorners();
    }

    private void TryRoundCorners()
    {
        try
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            int preference = 1;
            try { if ((_settings.Load().CornerStyle ?? "win10") == "win11") preference = 0; } catch { }
            DwmSetWindowAttribute(hwnd, 33, ref preference, sizeof(int));
        }
        catch { }
    }

    private bool _autoScrolling;
    private readonly Dictionary<string, double> _scrollMemory = new();
    private bool _restoreScrollArmed;
    private bool _suppressScrollSave;
    private System.Windows.Point _autoAnchor;
    private double _autoVelocity;
    private readonly DispatcherTimer _autoScrollTimer = new() { Interval = TimeSpan.FromMilliseconds(30) };
    private readonly DispatcherTimer _scrollbarIdle = new() { Interval = TimeSpan.FromSeconds(1) };
    private const double AutoScrollDeadZone = 15;
    private const double AutoScrollFactor = 0.12;

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
    private System.Windows.Controls.Primitives.Popup? _activeInfoPopup;
    private FrameworkElement? _pendingInfoIcon;

    private void InfoPopupShowTick(object? sender, EventArgs e)
    {
        _infoPopupShowTimer.Stop();
        _infoPopupShowTimer.Tick -= InfoPopupShowTick;
        if (_pendingInfoIcon is FrameworkElement fe)
        {
            _activeInfoPopup = fe.FindName("InfoPopup") as System.Windows.Controls.Primitives.Popup;
            if (_activeInfoPopup == null) return;
            _activeInfoPopup.IsOpen = true;
            try
            {
                // ponytail: explicit open animation — PopupAnimation alone renders instant on some systems
                if (_activeInfoPopup.Child is FrameworkElement card)
                {
                    card.RenderTransform = new TranslateTransform();
                    card.BeginAnimation(OpacityProperty, new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(220)));
                    card.RenderTransform.BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation(-10, 0, TimeSpan.FromMilliseconds(220)) { EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut } });
                }
            }
            catch { }
        }
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
            : (delta - Math.Sign(delta) * AutoScrollDeadZone) * AutoScrollFactor;
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



    private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        const int wmGetMinMaxInfo = 0x0024;
        const int wmSettingChange = 0x001A;
        if (msg == wmSettingChange && lParam != IntPtr.Zero)
        {
            // ponytail: auto theme follows Windows light/dark live, no polling, no new deps
            try
            {
                if (Marshal.PtrToStringUni(lParam) == "ImmersiveColorSet" && DataContext is MainViewModel vm)
                    vm.OnSystemThemeChanged();
            }
            catch { }
            return IntPtr.Zero;
        }
        if (msg != wmGetMinMaxInfo) return IntPtr.Zero;

        var monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);
        if (monitor == IntPtr.Zero) return IntPtr.Zero;

        var info = Marshal.PtrToStructure<MINMAXINFO>(lParam);
        var monitorInfo = new MONITORINFO();
        monitorInfo.cbSize = Marshal.SizeOf(typeof(MONITORINFO));
        GetMonitorInfo(monitor, ref monitorInfo);
        info.ptMaxPosition.x = Math.Abs(monitorInfo.rcWork.left - monitorInfo.rcMonitor.left);
        info.ptMaxPosition.y = Math.Abs(monitorInfo.rcWork.top - monitorInfo.rcMonitor.top);
        info.ptMaxSize.x = Math.Abs(monitorInfo.rcWork.right - monitorInfo.rcWork.left);
        info.ptMaxSize.y = Math.Abs(monitorInfo.rcWork.bottom - monitorInfo.rcWork.top);
        try
        {
            uint dpi = GetDpiForWindow(hwnd);
            double factor = dpi / 96.0;
            if (factor < 1) factor = 1;
            info.ptMinTrackSize.x = (int)(980 * factor);
            info.ptMinTrackSize.y = (int)(580 * factor);
        }
        catch
        {
            info.ptMinTrackSize.x = 980;
            info.ptMinTrackSize.y = 580;
        }
        Marshal.StructureToPtr(info, lParam, true);
        handled = true;
        return IntPtr.Zero;
    }

    private void OverlayBackground_Click(object sender, MouseButtonEventArgs e)
    {
        if (sender is Grid grid && e.OriginalSource == grid)
        {
            if (grid == QuantumMapOverlay) ((MainViewModel)DataContext).CloseQuantumMapCommand.Execute(null);
        }
    }

    private void SettingsOverlay_Click(object sender, MouseButtonEventArgs e)
    {
        if (sender is Grid grid && e.OriginalSource == grid)
            ((MainViewModel)DataContext).HideSettingsDialogCommand.Execute(null);
    }

    private void OnMinimizeClick(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

    private void OnMaximizeClick(object sender, RoutedEventArgs e) =>
        WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;

    private void OnCloseClick(object sender, RoutedEventArgs e) => Close();

    private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
    {
        try { System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true }); } catch { }
        e.Handled = true;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct POINT { public int x; public int y; }

    [StructLayout(LayoutKind.Sequential)]
    private struct MINMAXINFO
    {
        public POINT ptReserved;
        public POINT ptMaxSize;
        public POINT ptMaxPosition;
        public POINT ptMinTrackSize;
        public POINT ptMaxTrackSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct RECT { public int left, top, right, bottom; }

    [StructLayout(LayoutKind.Sequential)]
    private struct MONITORINFO
    {
        public int cbSize;
        public RECT rcMonitor;
        public RECT rcWork;
        public uint dwFlags;
    }

    private const int MONITOR_DEFAULTTONEAREST = 2;

    [DllImport("user32.dll")]
    private static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint flags);

    [DllImport("user32.dll")]
    private static extern bool GetMonitorInfo(IntPtr monitor, ref MONITORINFO info);

    [DllImport("user32.dll")]
    private static extern uint GetDpiForWindow(IntPtr hwnd);

    [DllImport("dwmapi.dll")]
    private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attribute, ref int value, int size);
}
