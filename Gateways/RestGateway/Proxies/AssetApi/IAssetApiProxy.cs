using RestGateway.Proxies.AssetApi.Models.Requests;
using RestGateway.Proxies.AssetApi.Models.Responses;

namespace RestGateway.Proxies.AssetApi
{
    public interface IAssetApiProxy
    {
        Task<List<QueryAssetApiResponse>> QueryAssets(QueryAssetApiRequest assetApiRequest);
    }
}
