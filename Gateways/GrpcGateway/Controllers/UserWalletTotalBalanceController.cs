
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace GrpcGateway.Controllers
{
    [Route("api/user-wallet-total-balance")]
    [ApiController]
    public class UserWalletTotalBalanceController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UserWalletTotalBalanceController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserWalletTotalBalance()
        {
            var userBrokerages = await QueryUserBrokerages();

            var userBrokerageAccounts = await QueryUserBrokerageAccounts();

            var userAccountFiatBalanceTask = GetUserAccountFiatBalance();

            var taskAssetBalances = QueryUserAccountAssetBalances();

            await Task.WhenAll(userAccountFiatBalanceTask, taskAssetBalances);

            var assets = await QueryAssets();

            return Ok("Grpc gateway works");
        }

        public async Task<List<QueryAssetResponseItem>> QueryAssets()
        {
            using GrpcChannel channel = GrpcChannel.ForAddress(_configuration["AssetGrpcUrl"]);

            Asset.AssetClient assetClient = new Asset.AssetClient(channel);

            var reply = await assetClient.QueryAssetsAsync(new QueryAssetRequest());

            return reply.Items.ToList();
        }

        public async Task<List<QueryUserBrokerageAccountResponseItem>> QueryUserBrokerageAccounts()
        {
            using GrpcChannel channel = GrpcChannel.ForAddress(_configuration["UserGrpcUrl"]);

            UserBrokerageAccount.UserBrokerageAccountClient userBrokerageAccountClient = new UserBrokerageAccount.UserBrokerageAccountClient(channel);

            QueryUserBrokerageAccountRequest request = new QueryUserBrokerageAccountRequest
            {
                UserBrokerageId = 1,
                UserAccountId = 1
            };

            var reply = await userBrokerageAccountClient.QueryUserBrokerageAccountsAsync(request);

            return reply.Items.ToList();
        }

        public async Task<List<QueryUserBrokerageResponseItem>> QueryUserBrokerages()
        {
            using GrpcChannel channel = GrpcChannel.ForAddress(_configuration["UserGrpcUrl"]);

            UserBrokerage.UserBrokerageClient userBrokerageClient = new UserBrokerage.UserBrokerageClient(channel);

            QueryUserBrokerageRequest request = new QueryUserBrokerageRequest
            {
                Type = BrokerageType.Infina,
                UserId = 1,
            };

            var reply = await userBrokerageClient.QueryUserBrokeragesAsync(request);

            return reply.Items.ToList();
        }

        public async Task<List<QueryUserAccountAssetBalanceResponseItem>> QueryUserAccountAssetBalances()
        {
            using GrpcChannel channel = GrpcChannel.ForAddress(_configuration["WalletGrpcUrl"]);

            UserAccountAssetBalance.UserAccountAssetBalanceClient userAccountAssetBalanceClient = new UserAccountAssetBalance.UserAccountAssetBalanceClient(channel);

            QueryUserAccountAssetBalanceRequest request = new QueryUserAccountAssetBalanceRequest
            {
                BrokerageAccountId = "1"
            };

            var reply = await userAccountAssetBalanceClient.QueryUserAccountAssetBalancesAsync(request);

            return reply.Items.ToList();
        }

        public async Task<GetUserAccountFiatBalanceResponse> GetUserAccountFiatBalance()
        {
            using GrpcChannel channel = GrpcChannel.ForAddress(_configuration["WalletGrpcUrl"]);

            UserAccountFiatBalance.UserAccountFiatBalanceClient userAccountAssetBalanceClient = new UserAccountFiatBalance.UserAccountFiatBalanceClient(channel);

            GetUserAccountFiatBalanceRequest request = new GetUserAccountFiatBalanceRequest
            {
                BrokerageAccountId = "1"
            };

            var reply = await userAccountAssetBalanceClient.GetUserAccountFiatBalanceAsync(request);

            return reply;
        }
    }
}
