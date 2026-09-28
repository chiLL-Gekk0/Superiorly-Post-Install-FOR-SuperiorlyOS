using System.Globalization;
using System.Windows.Data;

namespace Superiorly.PostInstall.Converters;

public sealed class RowWidthConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var w = value is double d ? d : 0;
        var sub = parameter is string s && double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var p) ? p : 0;
        return Math.Max(0, w - sub);
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
}
