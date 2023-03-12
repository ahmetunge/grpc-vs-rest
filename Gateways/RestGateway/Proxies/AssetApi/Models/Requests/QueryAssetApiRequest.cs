using RestGateway.Proxies.AssetApi.Models.Enums;
using System.Text.Json.Serialization;

namespace RestGateway.Proxies.AssetApi.Models.Requests
{
    public class QueryAssetApiRequest
    {
        [JsonPropertyName("assetStatus")]
        public AssetStatus? AssetStatus { get; set; }
    }
}
