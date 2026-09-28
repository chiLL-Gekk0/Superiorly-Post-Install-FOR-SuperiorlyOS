using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Superiorly.PostInstall.Converters;

public class LogoConverter : IValueConverter
{
    [DllImport("user32.dll")]
    private static extern uint GetDpiForWindow(IntPtr hwnd);

    private static readonly System.Collections.Concurrent.ConcurrentDictionary<string, ImageSource?> ImageCache = new();
    private static double? _cachedScale;

    private static double Scale
    {
        get
        {
            if (_cachedScale.HasValue) return _cachedScale.Value;
            double scale = 1.0;
            try
            {
                var win = Application.Current?.MainWindow;
                if (win != null)
                {
                    var hwnd = new WindowInteropHelper(win).Handle;
                    if (hwnd != IntPtr.Zero)
                    {
                        var dpi = GetDpiForWindow(hwnd);
                        if (dpi != 0) scale = dpi / 96.0;
                    }
                    else
                    {
                        scale = VisualTreeHelper.GetDpi(win).DpiScaleX;
                    }
                }
            }
            catch { scale = 1.0; }
            _cachedScale = scale;
            return scale;
        }
    }

    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not string path || string.IsNullOrWhiteSpace(path)) return null;
        int displaySize = 40;
        if (parameter is string ps && int.TryParse(ps, out var p)) displaySize = p;
        else if (parameter is int pi) displaySize = pi;
        var key = path + "|" + displaySize;
        if (ImageCache.TryGetValue(key, out var cached)) return cached;
        var created = Create(path, displaySize);
        ImageCache[key] = created;
        return created;
    }

    private static ImageSource? Create(string path, int displaySize)
    {
        try
        {
            var uri = new Uri($"pack://application:,,{path}", UriKind.Absolute);
            int decode = (int)Math.Round(displaySize * Scale);
            decode = Math.Clamp(decode, 32, 256);
            var bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.UriSource = uri;
            bmp.DecodePixelWidth = decode;
            bmp.CacheOption = BitmapCacheOption.OnLoad;
            bmp.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
            bmp.EndInit();
            bmp.Freeze();
            return bmp;
        }
        catch { return null; }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        throw new NotImplementedException();
}
