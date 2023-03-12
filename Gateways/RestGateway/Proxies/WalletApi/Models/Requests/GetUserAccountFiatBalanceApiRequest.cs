using System.Text.Json.Serialization;

namespace RestGateway.Proxies.WalletApi.Models.Requests
{
    public class GetUserAccountFiatBalanceApiRequest
    {
        [JsonPropertyName("brokerageAccountId")]
        public string BrokerageAccountId { get; set; }
    }
}
