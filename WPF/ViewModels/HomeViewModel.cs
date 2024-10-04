namespace WPF.ViewModels;

internal class HomeViewModel : NotifyPropertyChangedBase
{
    private readonly CoinCapService coinCapService;

    private ObservableCollection<Currency> topCurrencies;
    public ObservableCollection<Currency> TopCurrencies
    {
        get => topCurrencies;
        set => SetProperty(ref topCurrencies, value);
    }

    private ObservableCollection<Currency> allCurrencies;
    public ObservableCollection<Currency> AllCurrencies
    {
        get => allCurrencies;
        set => SetProperty(ref allCurrencies, value);
    }

    private List<Currency> allCurrenciesCache;

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
        LoadDataAsync();
    }

    private async void LoadDataAsync()
    {
        Task.Run(LoadTopCurrenciesAsync);
        Task.Run(LoadAllCurrenciesAsync);
    }

    public async Task LoadTopCurrenciesAsync()
    {
        IsTopLoading = true;
        try
        {
            await Task.Delay(3000); // delay for testing
            var currencies = await coinCapService.GetTopNAsync(10);
            TopCurrencies = new ObservableCollection<Currency>(currencies);
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
            await Task.Delay(3000); // delay for testing
            allCurrenciesCache = await coinCapService.GetAllAsync();
            AllCurrencies = new ObservableCollection<Currency>(allCurrenciesCache);
        }
        finally
        {
            IsAllLoading = false;
        }
    }

    private string searchQuery;

    public string SearchQuery
    {
        get => searchQuery;
        set
        {
            searchQuery = value?.Trim();
            OnPropertyChanged();
            SearchCryptocurrencies();
        }
    }

    private void SearchCryptocurrencies()
    {
        if (string.IsNullOrWhiteSpace(SearchQuery))
        {
            AllCurrencies = new ObservableCollection<Currency>(allCurrenciesCache);
        }
        else
        {
            var filtered = allCurrenciesCache.Where(c =>
                        c.Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)
                        || c.Symbol.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)
                        || c.Rank.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase));

            AllCurrencies = new ObservableCollection<Currency>(filtered);
        }
    }
}
