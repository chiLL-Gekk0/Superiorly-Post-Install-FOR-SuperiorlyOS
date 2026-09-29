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



        // per-section scroll memory: save on scroll, restore once after refill
        string ScrollKey() => ((DataContext as MainViewModel)?.SelectedSection?.Id ?? "") + "/" + ((DataContext as MainViewModel)?.SelectedTab?.Id ?? "");
        CardsScroll.ScrollChanged += (_, _) =>
        {
            // programmatic scrolls must not overwrite memory
            if (_suppressScrollSave) return;
            try { _scrollMemory[ScrollKey()] = CardsScroll.VerticalOffset; } catch { }
        };
        // scrollbar visible only while scrolling, fade out after 1s idle
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
                    // restore-first: saved offset wins, else top
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

    private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        const int wmGetMinMaxInfo = 0x0024;
        const int wmSettingChange = 0x001A;
        if (msg == wmSettingChange && lParam != IntPtr.Zero)
        {
            // auto theme follows windows light/dark live, no polling, no new deps
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
