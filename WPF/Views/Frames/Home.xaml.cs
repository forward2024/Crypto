namespace WPF.Views.Frames;

public partial class Home : Page
{
    public Home()
    {
        InitializeComponent();
        this.DataContext = new HomeViewModel();
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        AllCurrenciesListBox.SelectedItem = null;
        ExchangesListBox.SelectedItem = null;
    }

    private void Select_curr(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count > 0)
        {
            var selectedCurrency = e.AddedItems[0] as Currency;
            if (selectedCurrency != null)
            {
                if (NavigationService.Content is not DetailsPage)
                {
                    NavigationService.Navigate(new DetailsPage(selectedCurrency));
                }
            }
        }
    }

    private void VisitExchange(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var exchange = button?.DataContext as Exchange;
        if (exchange != null && !string.IsNullOrEmpty(exchange.ExchangeUrl))
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = exchange.ExchangeUrl,
                UseShellExecute = true
            });
        }
    }

    //private void ExchangeSelected(object sender, SelectionChangedEventArgs e)
    //{
    //    if (e.AddedItems.Count > 0)
    //    {
    //        var selectedExchange = e.AddedItems[0] as Exchange;
    //        if (selectedExchange != null && !string.IsNullOrEmpty(selectedExchange.ExchangeUrl))
    //        {
    //            System.Diagnostics.Process.Start(new ProcessStartInfo
    //            {
    //                FileName = selectedExchange.ExchangeUrl,
    //                UseShellExecute = true
    //            });
    //        }
    //    }
    //}
}
