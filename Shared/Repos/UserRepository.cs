using Bogus;
using Shared.Requests;
using Shared.Responses;

namespace Shared.Repos
{
    public class UserRepository : IUserRepository
    {
        public IReadOnlyList<QueryUserBrokerageResponse> QueryUserBrokerages(QueryUserBrokerageRequest request)
        {
            List<QueryUserBrokerageResponse> userBrokerages = new Faker<QueryUserBrokerageResponse>()
                .RuleFor(x => x.Id, f => f.Random.Int(1))
                .RuleFor(x => x.BrokerageId, f => f.Random.Int(1))
                .RuleFor(x => x.ReferenceId, f => f.Random.String2(1, 25))
                .RuleFor(x => x.UserId, f => f.Random.Int(1))
                .Generate(1);

            return userBrokerages.AsReadOnly();
        }

        public IReadOnlyList<QueryUserBrokerageAccountResponse> QueryUserBrokerageAccounts(QueryUserBrokerageAccountRequest request)
        {

            List<QueryUserBrokerageAccountResponse> userBrokerages = new Faker<QueryUserBrokerageAccountResponse>()
                .RuleFor(x => x.Id, f => f.Random.Int(1))
                .RuleFor(x => x.UserBrokerageId, f => f.Random.Int(1))
                .RuleFor(x => x.ReferenceId, f => f.Random.String2(1, 25))
                .RuleFor(x => x.UserAccountId, f => f.Random.Int(1))
                .Generate(1);

            return userBrokerages.AsReadOnly();
        }
    }

    public interface IUserRepository
    {
        IReadOnlyList<QueryUserBrokerageResponse> QueryUserBrokerages(QueryUserBrokerageRequest request);

        IReadOnlyList<QueryUserBrokerageAccountResponse> QueryUserBrokerageAccounts(QueryUserBrokerageAccountRequest request);
    }
}
