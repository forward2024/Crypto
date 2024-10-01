namespace WPF.Helpers;

internal class InverseBooleanToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool flag = (bool)value;
        return flag ? Visibility.Collapsed : Visibility.Visible;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Visibility visibility = (Visibility)value;
        return visibility != Visibility.Visible;
    }
}
