using RestGateway.Proxies.WalletApi.Models.Requests;
using RestGateway.Proxies.WalletApi.Models.Responses;

namespace RestGateway.Proxies.WalletApi
{
    public interface IWalletApiProxy
    {
        Task<ProxyResponse<GetUserAccountFiatBalanceApiResponse>> GetUserAccountFiatBalance(GetUserAccountFiatBalanceApiRequest request);

        Task<ProxyResponse<List<QueryUserAccountAssetBalanceApiResponse>>> QueryUserAccountAssetBalances(QueryUserAccountAssetBalanceApiRequest request);

    }
}
