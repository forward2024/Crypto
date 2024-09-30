using WPF.Services;

namespace WPF.Views.Frames;


public partial class Home : Page
{
    private CoinCapService coinCapService;

    public Home()
    {
        InitializeComponent();
        this.coinCapService = new CoinCapService();
        Loaded += async (s, e) => await LoadCurrencies();
    }

    private async Task LoadCurrencies()
    {
        var currencies = await coinCapService.GetTopNAsync(100);
        CryptoList.ItemsSource = currencies;
    }
}
