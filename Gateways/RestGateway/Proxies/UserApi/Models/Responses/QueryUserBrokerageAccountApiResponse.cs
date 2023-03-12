using System.Text.Json.Serialization;

namespace RestGateway.Proxies.UserApi.Models.Responses
{
    public class QueryUserBrokerageAccountApiResponse
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("userBrokerageId")]
        public long UserBrokerageId { get; set; }

        [JsonPropertyName("referenceId")]
        public string ReferenceId { get; set; }

        [JsonPropertyName("userAccountId")]
        public long UserAccountId { get; set; }
    }
}
