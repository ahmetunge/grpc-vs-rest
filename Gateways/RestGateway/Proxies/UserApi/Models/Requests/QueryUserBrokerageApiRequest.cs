using RestGateway.Proxies.UserApi.Models.Enums;
using System.Text.Json.Serialization;

namespace RestGateway.Proxies.UserApi.Models.Requests
{
    public class QueryUserBrokerageApiRequest
    {
        [JsonPropertyName("userId")]
        public long? UserId { get; set; }

        [JsonPropertyName("brokerageType")]
        public BrokerageType? Type { get; set; }
    }
}
