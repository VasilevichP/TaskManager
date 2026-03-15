using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using WpfApp1.Models;

namespace WpfApp1.Converters;

public class StatusToForegroundConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is TodoStatus status)
        {
            return status switch
            {
                TodoStatus.New => new SolidColorBrush(Color.FromRgb(59, 130, 246)),
                TodoStatus.InProgress => new SolidColorBrush(Color.FromRgb(245, 158, 11)),
                TodoStatus.Completed => new SolidColorBrush(Color.FromRgb(16, 185, 129)), 
                _ => Brushes.Gray
            };
        }
        return Brushes.Gray;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}