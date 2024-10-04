namespace WPF.Models;


#pragma warning disable CS8618
public class Currency
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("rank")]
    public string Rank { get; set; }

    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("supply")]
    public double? Supply { get; set; }

    [JsonProperty("maxSupply")]
    public double? MaxSupply { get; set; }

    [JsonProperty("marketCapUsd")]
    public string MarketCapUsd { get; set; }

    [JsonProperty("volumeUsd24Hr")]
    public double VolumeUsd24Hr { get; set; }

    [JsonProperty("priceUsd")]
    public double PriceUsd { get; set; }

    [JsonProperty("changePercent24Hr")]
    public double ChangePercent24Hr { get; set; }

    [JsonProperty("vwap24Hr")]
    public string Vwap24Hr { get; set; }
}

internal class CurrencyResponse
{
    [JsonProperty("data")]
    public List<Currency> Data { get; set; }
}