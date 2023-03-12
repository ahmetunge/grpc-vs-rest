using Microsoft.AspNetCore.Mvc;
using RestGateway.Proxies;
using RestGateway.Proxies.AssetApi;
using RestGateway.Proxies.AssetApi.Models.Requests;
using RestGateway.Proxies.AssetApi.Models.Responses;
using RestGateway.Proxies.UserApi;
using RestGateway.Proxies.UserApi.Models.Enums;
using RestGateway.Proxies.UserApi.Models.Requests;
using RestGateway.Proxies.UserApi.Models.Responses;
using RestGateway.Proxies.WalletApi;
using RestGateway.Proxies.WalletApi.Models.Requests;
using RestGateway.Proxies.WalletApi.Models.Responses;

namespace RestGateway.Controllers
{
    [Route("api/user-wallet-total-balance")]
    [ApiController]
    public class UserWalletTotalBalanceController : ControllerBase
    {
        private readonly IUserApiProxy _userApiProxy;
        private readonly IAssetApiProxy _assetApiProxy;
        private readonly IWalletApiProxy _walletApiProxy;

        public UserWalletTotalBalanceController(
            IUserApiProxy userApiProxy,
            IAssetApiProxy assetApiProxy,
            IWalletApiProxy walletApiProxy)
        {
            _userApiProxy = userApiProxy;
            _assetApiProxy = assetApiProxy;
            _walletApiProxy = walletApiProxy;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserWalletTotalBalance()
        {
            QueryUserBrokerageApiRequest userBrokerageApiRequest = new QueryUserBrokerageApiRequest
            {
                Type = BrokerageType.Infina,
                UserId = 1,
            };

            List<QueryUserBrokerageApiResponse> userBrokerages = await _userApiProxy.QueryUserBrokerages(userBrokerageApiRequest);

            QueryUserBrokerageAccountApiRequest userBrokerageAccountApiRequest = new QueryUserBrokerageAccountApiRequest
            {
                UserBrokerageId = userBrokerages.First().Id,
                UserAccountId = 1
            };

            List<QueryUserBrokerageAccountApiResponse> userBrokerageAccounts = await _userApiProxy.QueryUserBrokerageAccounts(userBrokerageAccountApiRequest);

            GetUserAccountFiatBalanceApiRequest userAccountFiatBalanceApiRequest = new GetUserAccountFiatBalanceApiRequest
            {
                BrokerageAccountId = "1"
            };

            Task<ProxyResponse<GetUserAccountFiatBalanceApiResponse>> userAccountFiatBalanceTask = _walletApiProxy.GetUserAccountFiatBalance(userAccountFiatBalanceApiRequest);

            QueryUserAccountAssetBalanceApiRequest assetBalanceApiRequest = new QueryUserAccountAssetBalanceApiRequest
            {
                BrokerageAccountId = "1"
            };

            Task<ProxyResponse<List<QueryUserAccountAssetBalanceApiResponse>>> taskAssetBalances = _walletApiProxy.QueryUserAccountAssetBalances(assetBalanceApiRequest);

            await Task.WhenAll(userAccountFiatBalanceTask, taskAssetBalances);

            QueryAssetApiRequest assetApiRequest = new QueryAssetApiRequest();

            List<QueryAssetApiResponse> assets = await _assetApiProxy.QueryAssets(assetApiRequest);

            return Ok("Rest Gateway Works");
        }
    }
}
