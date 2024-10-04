namespace WPF.Services;

internal class CoinCapService
{
    private readonly HttpClient httpClient;

    public CoinCapService()
    {
        httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://api.coincap.io/v2/")
        };
    }

    public async Task<List<Exchange>> GetExchangesAsync()
    {
        var response = await httpClient.GetAsync($"exchanges");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ExchangeResponse>(content);

        return result.Data;
    }

    public async Task<List<Currency>> GetAllAsync()
    {
        var response = await httpClient.GetAsync($"assets");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<CurrencyResponse>(content);

        return result.Data;
    }

    public async Task<List<HistoryData>> GetAssetHistoryAsync(string assetId, string interval = "d1")
    {
        var response = await httpClient.GetAsync($"assets/{assetId}/history?interval={interval}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<HistoryResponse>(content);

        return result.Data;
    }
}
