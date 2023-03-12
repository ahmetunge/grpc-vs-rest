using Bogus;
using Microsoft.AspNetCore.Mvc;

namespace UserApi.Controllers
{
    [Route("api/user-brokerage-accounts")]
    [ApiController]
    public class UserBrokerageAccountsController : ControllerBase
    {
        private readonly List<QueryUserBrokerageAccountResponse> _userBrokerageAccounts;

        public UserBrokerageAccountsController()
        {
            _userBrokerageAccounts = new Faker<QueryUserBrokerageAccountResponse>()
                .RuleFor(x => x.Id, f => f.Random.Int(1))
                .RuleFor(x => x.UserBrokerageId, f => f.Random.Int(1))
                .RuleFor(x => x.ReferenceId, f => f.Random.String2(1, 25))
                .RuleFor(x => x.UserAccountId, f => f.Random.Int(1))
                .Generate(1);
        }

        [HttpGet]
        public IActionResult QueryUserBrokerageAccounts([FromQuery] QueryUserBrokerageAccountRequest request)
        {
            return Ok(_userBrokerageAccounts);
        }
    }

    public class QueryUserBrokerageAccountRequest
    {
        public string? ReferenceId { get; set; }

        public long? UserAccountId { get; set; }

        public long? UserBrokerageId { get; set; }
    }

    public class QueryUserBrokerageAccountResponse
    {
        public long Id { get; set; }

        public long UserBrokerageId { get; set; }

        public string ReferenceId { get; set; }

        public long UserAccountId { get; set; }
    }
}
