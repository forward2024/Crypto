namespace WPF.ViewModels;

internal class HomeViewModel : NotifyPropertyChangedBase
{
    private readonly CoinCapService coinCapService;

    private List<Currency> topCurrencies;
    public List<Currency> TopCurrencies
    {
        get => topCurrencies;
        set => SetProperty(ref topCurrencies, value);
    }

    private List<Currency> allCurrencies;
    public List<Currency> AllCurrencies
    {
        get => allCurrencies;
        set => SetProperty(ref allCurrencies, value);
    }

    private bool isTopLoading;
    public bool IsTopLoading
    {
        get => isTopLoading;
        set => SetProperty(ref isTopLoading, value);
    }

    private bool isAllLoading;
    public bool IsAllLoading
    {
        get => isAllLoading;
        set => SetProperty(ref isAllLoading, value);
    }

    public HomeViewModel()
    {
        coinCapService = new CoinCapService();

        Task.Run(LoadTopCurrenciesAsync);
        Task.Run(LoadAllCurrenciesAsync);
    }

    public async Task LoadTopCurrenciesAsync()
    {
        IsTopLoading = true;
        try
        {
            await Task.Delay(1000); // Затримка для тестування
            TopCurrencies = await coinCapService.GetTopNAsync(10);
        }
        finally
        {
            IsTopLoading = false;
        }
    }

    public async Task LoadAllCurrenciesAsync()
    {
        IsAllLoading = true;
        try
        {
            await Task.Delay(2000); // Затримка для тестування
            AllCurrencies = await coinCapService.GetAllAsync();
        }
        finally
        {
            IsAllLoading = false;
        }
    }
}
