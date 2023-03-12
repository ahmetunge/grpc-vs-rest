using Bogus;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace AssetApi.Controllers
{
    [Route("api/assets")]
    [ApiController]
    public class AssetsController : ControllerBase
    {

        IReadOnlyList<QueryAssetResponse> _assets;

        public AssetsController()
        {
            _assets = new Faker<QueryAssetResponse>()
                .RuleFor(x => x.Id, f => f.Random.Int(1))
                .RuleFor(x => x.Type, f => f.PickRandomWithout(AssetType.Unknown))
                .RuleFor(x => x.Name, f => f.Random.String2(2, 25))
                .RuleFor(x => x.Symbol, f => f.Random.String2(2, 6).ToUpper(new CultureInfo("en-GB")))
                .RuleFor(x => x.ExchangeId, f => f.Random.Int(1, 2))
                .RuleFor(x => x.MinPrice, f => f.Random.Double(0, 100))
                .RuleFor(x => x.MaxPrice, f => f.Random.Double(1, 100))
                .RuleFor(x => x.IsBuyable, true)
                .RuleFor(x => x.IsSellable, true)
                .RuleFor(x => x.Status, AssetStatus.Open)
                .RuleFor(x => x.SuitabilityRiskLevel, f => f.PickRandomWithout(SuitabilityRiskLevel.Unknown))
                .Generate(500);
        }

        [HttpGet]
        public IActionResult QueryAssets([FromQuery] QueryAssetRequest request)
        {
            return Ok(_assets);
        }


        public class QueryAssetRequest
        {
            public AssetStatus? AssetStatus { get; set; }
        }

        public class QueryAssetResponse
        {
            public int Id { get; set; }

            public AssetType Type { get; set; }

            public string Name { get; set; }

            public string Symbol { get; set; }

            public int ExchangeId { get; set; }

            public double MinPrice { get; set; }

            public double MaxPrice { get; set; }

            public bool IsBuyable { get; set; }

            public bool IsSellable { get; set; }

            public AssetStatus Status { get; set; }

            public SuitabilityRiskLevel SuitabilityRiskLevel { get; set; }
        }


        public enum SuitabilityRiskLevel
        {
            Unknown = 0,

            VeryLow = 1,

            Low = 2,

            Medium = 3,

            High = 4,

            VeryHigh = 5
        }

        public enum AssetStatus
        {
            Unknown = 0,

            Closed = 1,

            Open = 2,

            Suspended = 3
        }

        public enum AssetType
        {
            Unknown = 0,

            Equity = 1,

            Rights = 2
        }
    }
}
