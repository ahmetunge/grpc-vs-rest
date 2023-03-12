using Bogus;
using Microsoft.AspNetCore.Mvc;

namespace WalletApi.Controllers
{
    [Route("api/user-account-fiat-balance")]
    [ApiController]
    public class UserAccountFiatBalance : ControllerBase
    {
        private GetUserAccountFiatBalanceResponse _getUserAccountFiatBalanceResponse;

        public UserAccountFiatBalance()
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

            _getUserAccountFiatBalanceResponse.YieldBalances = new List<YieldBalance>();

            _getUserAccountFiatBalanceResponse.YieldBalances.AddRange(yieldBalances);
        }

        [HttpGet]
        public IActionResult GetUserAccountFiatBalance([FromQuery] GetUserAccountFiatBalanceRequest request)
        {
            return Ok(_getUserAccountFiatBalanceResponse);
        }

    }

    public class GetUserAccountFiatBalanceRequest
    {
        public string? BrokerageAccountId { get; set; }
    }

    public class GetUserAccountFiatBalanceResponse
    {
        public double BlockageAmount { get; set; }

        public double WithdrawableAmount { get; set; }

        public double CashInflowAmount { get; set; }

        public double CashOutflowAmount { get; set; }

        public List<YieldBalance> YieldBalances { get; set; }
    }

    public class YieldBalance
    {
        public int Id { get; set; }

        public double Amount { get; set; }
    }
}
