using Bogus;
using Grpc.Core;
using System.Globalization;

namespace WalletGrpc.Services
{
    public class UserAccountAssetBalanceService : UserAccountAssetBalance.UserAccountAssetBalanceBase
    {
        private readonly List<QueryUserAccountAssetBalanceResponseItem> _items;

        public UserAccountAssetBalanceService()
        {
            _items = new Faker<QueryUserAccountAssetBalanceResponseItem>()
                .RuleFor(x => x.Symbol, f => f.Random.String2(2, 10).ToUpper(new CultureInfo("en-GB")))
                .RuleFor(x => x.Price, f => f.Random.Double(1, 100))
                .RuleFor(x => x.TotalQuantity, f => f.Random.Double(1, 100))
                .RuleFor(x => x.TotalAmount, f => f.Random.Double(1, 100))
                .RuleFor(x => x.AvailableQuantity, f => f.Random.Double(1, 100))
                .RuleFor(x => x.AvailableAmount, f => f.Random.Double(1, 100))
                .Generate(10);
        }

        public override Task<QueryUserAccountAssetBalanceResponse> QueryUserAccountAssetBalances(QueryUserAccountAssetBalanceRequest request, ServerCallContext context)
        {
            return Task.FromResult(new QueryUserAccountAssetBalanceResponse
            {
                Items =
                {
                    _items
                }
            });
        }
    }
}