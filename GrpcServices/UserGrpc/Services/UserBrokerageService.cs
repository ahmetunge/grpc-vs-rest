using Bogus;
using Grpc.Core;

namespace UserGrpc.Services
{
    public class UserBrokerageService : UserBrokerage.UserBrokerageBase
    {
        private readonly List<QueryUserBrokerageResponseItem> _userBrokerages;

        public UserBrokerageService()
        {
            _userBrokerages = new Faker<QueryUserBrokerageResponseItem>()
                .RuleFor(x => x.Id, f => f.Random.Int(1))
                .RuleFor(x => x.BrokerageId, f => f.Random.Int(1))
                .RuleFor(x => x.ReferenceId, f => f.Random.String2(1, 25))
                .RuleFor(x => x.UserId, f => f.Random.Int(1))
                .Generate(1);
        }

        public override Task<QueryUserBrokerageResponse> QueryUserBrokerages(QueryUserBrokerageRequest request, ServerCallContext context)
        {
            return Task.FromResult(new QueryUserBrokerageResponse
            {
                Items =
                {
                    _userBrokerages
                }
            });
        }
    }
}
