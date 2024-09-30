﻿namespace WPF.Models;


#pragma warning disable CS8618
internal class Currency
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
    public string Supply { get; set; }

    [JsonProperty("maxSupply")]
    public string MaxSupply { get; set; }

    [JsonProperty("marketCapUsd")]
    public string MarketCapUsd { get; set; }

    [JsonProperty("volumeUsd24Hr")]
    public string VolumeUsd24Hr { get; set; }

    [JsonProperty("priceUsd")]
    public string PriceUsd { get; set; }

    [JsonProperty("changePercent24Hr")]
    public string ChangePercent24Hr { get; set; }

    [JsonProperty("vwap24Hr")]
    public string Vwap24Hr { get; set; }
}

internal class CurrencyResponse
{
    [JsonProperty("data")]
    public List<Currency> Data { get; set; }
}