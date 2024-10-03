namespace WPF.Helpers;

public class PlaceholderVisibilityConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        bool isEmpty = (bool)values[0];
        bool isFocused = (bool)values[1];
        return (isEmpty && !isFocused) ? Visibility.Visible : Visibility.Collapsed;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
