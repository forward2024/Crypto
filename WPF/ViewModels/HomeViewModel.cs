namespace WPF.ViewModels;

internal class HomeViewModel : NotifyPropertyChangedBase
{
    private readonly CoinCapService coinCapService;

    private ObservableCollection<Currency> allCurrencies;
    public ObservableCollection<Currency> AllCurrencies
    {
        get => allCurrencies;
        set => SetProperty(ref allCurrencies, value);
    }
    private List<Currency> allCurrenciesCache;

    private bool isAllLoading;
    public bool IsAllLoading
    {
        get => isAllLoading;
        set => SetProperty(ref isAllLoading, value);
    }


    private ObservableCollection<Exchange> exchanges;
    public ObservableCollection<Exchange> Exchanges
    {
        get => exchanges;
        set => SetProperty(ref exchanges, value);
    }
    private List<Exchange> exchangesCache;

    private bool isExchangesLoading;
    public bool IsExchangesLoading
    {
        get => isExchangesLoading;
        set => SetProperty(ref isExchangesLoading, value);
    }


    public HomeViewModel()
    {
        coinCapService = new CoinCapService();
        LoadDataAsync();
    }

    private async void LoadDataAsync()
    {
        Task.Run(LoadExchangesAsync);
        Task.Run(LoadAllCurrenciesAsync);
    }

    public async Task LoadExchangesAsync()
    {
        IsExchangesLoading = true;
        try
        {
            await Task.Delay(3000); // delay for testing
            exchangesCache = await coinCapService.GetExchangesAsync();
            Exchanges = new ObservableCollection<Exchange>(exchangesCache);
        }
        finally
        {
            IsExchangesLoading = false;
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
