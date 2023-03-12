using Bogus;
using Microsoft.AspNetCore.Mvc;

namespace UserApi.Controllers
{
    [Route("api/user-brokerages")]
    [ApiController]
    public class UserBrokeragesController : ControllerBase
    {
        private readonly List<QueryUserBrokerageResponse> _userBrokerages;

        public UserBrokeragesController()
        {
            _userBrokerages = new Faker<QueryUserBrokerageResponse>()
                .RuleFor(x => x.Id, f => f.Random.Int(1))
                .RuleFor(x => x.BrokerageId, f => f.Random.Int(1))
                .RuleFor(x => x.ReferenceId, f => f.Random.String2(1, 25))
                .RuleFor(x => x.UserId, f => f.Random.Int(1))
                .Generate(1);
        }

        [HttpGet]
        public IActionResult QueryUserBrokerages([FromQuery] QueryUserBrokerageRequest request)
        {
            return Ok(_userBrokerages);
        }
    }

    public class QueryUserBrokerageRequest
    {
        public long? UserId { get; set; }

        public BrokerageType? Type { get; set; }
    }

    public enum BrokerageType
    {
        Unknown = 0,

        Infina = 1
    }

    public class QueryUserBrokerageResponse
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string ReferenceId { get; set; }

        public int BrokerageId { get; set; }
    }
}
