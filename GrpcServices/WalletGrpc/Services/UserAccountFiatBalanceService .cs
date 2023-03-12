
using Bogus;
using Grpc.Core;

namespace WalletGrpc.Services
{
    public class UserAccountFiatBalanceService : UserAccountFiatBalance.UserAccountFiatBalanceBase
    {
        private GetUserAccountFiatBalanceResponse _getUserAccountFiatBalanceResponse;

        public UserAccountFiatBalanceService()
        {
            var yieldBalances = new Faker<YieldBalance>()
                .RuleFor(x => x.Id, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Amount, f => f.Random.Double(1, 100))
                .Generate(5);

            _getUserAccountFiatBalanceResponse = new Faker<GetUserAccountFiatBalanceResponse>()
                .RuleFor(x => x.BlockageAmount, f => f.Random.Double(1, 100))
                .RuleFor(x => x.CashInflowAmount, f => f.Random.Double(1, 100))
                .RuleFor(x => x.CashOutflowAmount, f => f.Random.Double(1, 100))
                .RuleFor(x => x.WithdrawableAmount, f => f.Random.Double(1, 100));

            _getUserAccountFiatBalanceResponse.YieldBalances.AddRange(yieldBalances);
        }

        public override Task<GetUserAccountFiatBalanceResponse> GetUserAccountFiatBalance(GetUserAccountFiatBalanceRequest request, ServerCallContext context)
        {
            return Task.FromResult(_getUserAccountFiatBalanceResponse);
        }
    }
}
