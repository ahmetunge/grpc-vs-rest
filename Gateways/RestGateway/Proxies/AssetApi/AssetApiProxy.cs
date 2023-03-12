using RestGateway.Extensions;
using RestGateway.Proxies.AssetApi.Models.Requests;
using RestGateway.Proxies.AssetApi.Models.Responses;
using System.Text.Json;

namespace RestGateway.Proxies.AssetApi
{
    public class AssetApiProxy : IAssetApiProxy
    {
        private readonly HttpClient _httpClient;

        public AssetApiProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<QueryAssetApiResponse>> QueryAssets(QueryAssetApiRequest request)
        {
            string url = $"/api/assets?{request.ToQueryString()}";

            HttpResponseMessage responseMessage = await _httpClient.GetAsync(url);

            string contentResponse = await responseMessage.Content.ReadAsStringAsync();

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Asset api /v1/assets endpoint get method call failed. StatusCode: {(int)responseMessage.StatusCode} Content: {contentResponse}");
            }

            List<QueryAssetApiResponse> assets = JsonSerializer.Deserialize<List<QueryAssetApiResponse>>(contentResponse);

            return assets;
        }
    }
}
