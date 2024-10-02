namespace WPF.Models;

public class HistoryData
{
    [JsonProperty("priceUsd")]
    public string PriceUsd { get; set; }

    [JsonProperty("time")]
    public long Time { get; set; }
}

public class HistoryResponse
{
    [JsonProperty("data")]
    public List<HistoryData> Data { get; set; }
}