using System.Text.Json.Serialization;

namespace RestGateway.Proxies.UserApi.Models.Requests
{
    public class QueryUserBrokerageAccountApiRequest
    {
        [JsonPropertyName("referenceId")]
        public string ReferenceId { get; set; }

        [JsonPropertyName("userAccountId")]
        public long? UserAccountId { get; set; }

        [JsonPropertyName("userBrokerageId")]
        public long? UserBrokerageId { get; set; }
    }
}
