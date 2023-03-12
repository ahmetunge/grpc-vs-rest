using System.Text.Json.Serialization;

namespace RestGateway.Proxies.UserApi.Models.Responses
{
    public class QueryUserBrokerageApiResponse
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("userId")]
        public long UserId { get; set; }

        [JsonPropertyName("referenceId")]
        public string ReferenceId { get; set; }

        [JsonPropertyName("brokerageId")]
        public int BrokerageId { get; set; }
    }
}
