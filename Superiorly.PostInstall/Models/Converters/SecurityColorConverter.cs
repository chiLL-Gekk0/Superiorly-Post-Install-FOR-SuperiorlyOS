using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Superiorly.PostInstall.Converters;

public class SecurityColorConverter : IValueConverter
{
    // themed via tryfindresource so scores stay readable; frozen fallbacks if theme missing
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int score)
        {
            if (score <= 3) return ScoreBrush("B_ScoreLow", 0xF8, 0x51, 0x49);
            if (score <= 6) return ScoreBrush("B_ScoreMid", 0xD2, 0x99, 0x22);
            return ScoreBrush("B_ScoreHigh", 0x3F, 0xB9, 0x50);
        }
        return ScoreBrush("B_ScoreMuted", 0x8B, 0x94, 0x9E);
    }

    private static SolidColorBrush ScoreBrush(string key, byte r, byte g, byte b)
    {
        try
        {
            if (System.Windows.Application.Current?.TryFindResource(key) is SolidColorBrush themed)
                return themed;
        }
        catch { }
        return Freeze(new(Color.FromRgb(r, g, b)));
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        throw new NotImplementedException();

    private static SolidColorBrush Freeze(SolidColorBrush brush)
    {
        brush.Freeze();
        return brush;
    }
}
