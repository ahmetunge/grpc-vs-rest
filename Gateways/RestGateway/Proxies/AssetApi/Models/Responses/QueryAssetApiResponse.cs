using RestGateway.Proxies.AssetApi.Models.Enums;
using System.Text.Json.Serialization;

namespace RestGateway.Proxies.AssetApi.Models.Responses
{
    public class QueryAssetApiResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("exchangeId")]
        public int ExchangeId { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("status")]
        public AssetStatus Status { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("type")]
        public AssetType Type { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("marketSegment")]
        public MarketSegment MarketSegment { get; set; }

        [JsonPropertyName("minPrice")]
        public double MinPrice { get; set; }

        [JsonPropertyName("maxPrice")]
        public double MaxPrice { get; set; }

        [JsonPropertyName("isSellable")]
        public bool IsSellable { get; set; }

        [JsonPropertyName("isBuyable")]
        public bool IsBuyable { get; set; }

        [JsonPropertyName("suitabilityRiskLevel")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SuitabilityRiskLevel SuitabilityRiskLevel { get; set; }
    }
}
