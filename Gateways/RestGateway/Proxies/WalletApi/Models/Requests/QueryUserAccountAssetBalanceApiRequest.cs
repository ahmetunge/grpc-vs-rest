using System.Text.Json.Serialization;

namespace RestGateway.Proxies.WalletApi.Models.Requests
{
    public class QueryUserAccountAssetBalanceApiRequest
    {
        [JsonPropertyName("brokerageAccountId")]
        public string BrokerageAccountId { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
    }
}
