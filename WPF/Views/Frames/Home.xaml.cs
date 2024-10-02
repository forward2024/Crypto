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
        TopCurrenciesListBox.SelectedItem = null;
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
}
