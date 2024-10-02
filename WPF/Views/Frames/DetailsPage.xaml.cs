namespace WPF.Views.Frames;

public partial class DetailsPage : Page
{ 
    public DetailsPage(Currency selectedCurrency)
    {
        InitializeComponent();
        this.DataContext = new DetailsViewModel(selectedCurrency);
    }
}
