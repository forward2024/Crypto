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

    public async Task<List<Currency>> GetTopNAsync(int n)
    {
        var response = await httpClient.GetAsync($"assets?limit={n}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<CurrencyResponse>(content);

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
}
