using System.Text.Json.Serialization;

namespace RestGateway.Proxies.WalletApi.Models.Responses
{
    public class GetUserAccountFiatBalanceApiResponse
    {
        [JsonPropertyName("blockageAmount")]
        public double BlockageAmount { get; set; }

        [JsonPropertyName("withdrawableAmount")]
        public double WithdrawableAmount { get; set; }

        [JsonPropertyName("cashInflowAmount")]
        public double CashInflowAmount { get; set; }

        [JsonPropertyName("cashOutflowAmount")]
        public double CashOutflowAmount { get; set; }

        [JsonPropertyName("yieldBalances")]
        public List<YieldBalance> YieldBalances { get; set; }
    }

    public class YieldBalance
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }
    }
}
