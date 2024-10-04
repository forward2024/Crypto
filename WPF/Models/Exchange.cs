namespace WPF.Models;


public class Exchange
{
    [JsonProperty("exchangeId")]
    public string? ExchangeId { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("rank")]
    public string Rank { get; set; }

    [JsonProperty("percentTotalVolume")]
    public string? PercentTotalVolume { get; set; }

    [JsonProperty("volumeUsd")]
    public double? VolumeUsd { get; set; }

    [JsonProperty("tradingPairs")]
    public int? TradingPairs { get; set; }

    [JsonProperty("socket")]
    public bool? Socket { get; set; }

    [JsonProperty("exchangeUrl")]
    public string? ExchangeUrl { get; set; }

    [JsonProperty("updated")]
    public long? Updated { get; set; }
}

internal class ExchangeResponse
{
    [JsonProperty("data")]
    public List<Exchange> Data { get; set; }
}
