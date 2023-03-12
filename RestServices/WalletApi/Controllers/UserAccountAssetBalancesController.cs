using Bogus;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace WalletApi.Controllers
{
    [Route("api/user-account-asset-balances")]
    [ApiController]
    public class UserAccountAssetBalancesController : ControllerBase
    {
        private readonly List<QueryUserAccountAssetBalanceResponse> _items;

        public UserAccountAssetBalancesController()
        {
            _items = new Faker<QueryUserAccountAssetBalanceResponse>()
                .RuleFor(x => x.Symbol, f => f.Random.String2(2, 10).ToUpper(new CultureInfo("en-GB")))
                .RuleFor(x => x.Price, f => f.Random.Double(1, 100))
                .RuleFor(x => x.TotalQuantity, f => f.Random.Double(1, 100))
                .RuleFor(x => x.TotalAmount, f => f.Random.Double(1, 100))
                .RuleFor(x => x.AvailableQuantity, f => f.Random.Double(1, 100))
                .RuleFor(x => x.AvailableAmount, f => f.Random.Double(1, 100))
                .Generate(10);
        }

        [HttpGet]
        public IActionResult QueryUserAccountAssetBalances([FromQuery] QueryUserAccountAssetBalanceRequest request)
        {
            return Ok(_items);
        }

        public class QueryUserAccountAssetBalanceRequest
        {
            public string? BrokerageAccountId { get; set; }

            public string? Symbol { get; set; }
        }

        public class QueryUserAccountAssetBalanceResponse
        {
            public string Symbol { get; set; }

            public double Price { get; set; }

            public double TotalQuantity { get; set; }

            public double TotalAmount { get; set; }

            public double AvailableQuantity { get; set; }

            public double AvailableAmount { get; set; }
        }
    }
}
