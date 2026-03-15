
using System.Globalization;
using System.Windows.Data;
using WpfApp1.Models;

namespace WpfApp1.Converters;

public class StatusToStringConverter:IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is TodoStatus status)
        {
            return status switch
            {
                TodoStatus.New => "Новая",
                TodoStatus.InProgress => "В процессе",
                TodoStatus.Completed => "Завершена", 
                _ => "-"
            };
        }
        return string.Empty;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}