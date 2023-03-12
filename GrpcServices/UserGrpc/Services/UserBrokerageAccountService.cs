using Bogus;
using Grpc.Core;

namespace UserGrpc.Services
{
    public class UserBrokerageAccountService : UserBrokerageAccount.UserBrokerageAccountBase
    {
        private readonly List<QueryUserBrokerageAccountResponseItem> _userBrokerageAccounts;

        public UserBrokerageAccountService()
        {
            _userBrokerageAccounts = new Faker<QueryUserBrokerageAccountResponseItem>()
                 .RuleFor(x => x.Id, f => f.Random.Int(1))
                 .RuleFor(x => x.UserBrokerageId, f => f.Random.Int(1))
                 .RuleFor(x => x.ReferenceId, f => f.Random.String2(1, 25))
                 .RuleFor(x => x.UserAccountId, f => f.Random.Int(1))
                 .Generate(1);
        }

        public override Task<QueryUserBrokerageAccountResponse> QueryUserBrokerageAccounts(QueryUserBrokerageAccountRequest request, ServerCallContext context)
        {
            return Task.FromResult(new QueryUserBrokerageAccountResponse
            {
                Items =
                {
                    _userBrokerageAccounts
                }
            });
        }
    }
}
