using System.Text.Json.Serialization;

namespace RestGateway.Proxies.WalletApi.Models.Responses
{
    public class QueryUserAccountAssetBalanceApiResponse
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("totalQuantity")]
        public double TotalQuantity { get; set; }

        [JsonPropertyName("totalAmount")]
        public double TotalAmount { get; set; }

        [JsonPropertyName("availableQuantity")]
        public double AvailableQuantity { get; set; }

        [JsonPropertyName("availableAmount")]
        public double AvailableAmount { get; set; }
    }
}
