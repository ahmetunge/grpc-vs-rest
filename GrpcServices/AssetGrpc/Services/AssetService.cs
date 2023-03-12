using Bogus;
using Grpc.Core;
using System.Globalization;

namespace AssetGrpc.Services
{
    public class AssetService : Asset.AssetBase
    {
        private List<QueryAssetResponseItem> _assets;

        public AssetService()
        {
            _assets = new Faker<QueryAssetResponseItem>()
                .RuleFor(x => x.Id, f => f.Random.Int(1))
                .RuleFor(x => x.Type, f => f.PickRandomWithout(AssetType.Unknown))
                .RuleFor(x => x.Name, f => f.Random.String2(2, 25))
                .RuleFor(x => x.Symbol, f => f.Random.String2(2, 6).ToUpper(new CultureInfo("en-GB")))
                .RuleFor(x => x.ExchangeId, f => f.Random.Int(1, 2))
                .RuleFor(x => x.MinPrice, f => f.Random.Double(1, 100))
                .RuleFor(x => x.MaxPrice, f => f.Random.Double(1, 100))
                .RuleFor(x => x.IsBuyable, true)
                .RuleFor(x => x.IsSellable, true)
                .RuleFor(x => x.Status, AssetStatus.Open)
                .RuleFor(x => x.SuitabilityRiskLevel, f => f.PickRandomWithout(SuitabilityRiskLevel.Unknown))
                .Generate(500);
        }

        public override Task<QueryAssetResponse> QueryAssets(QueryAssetRequest request, ServerCallContext context)
        {
            return Task.FromResult(new QueryAssetResponse
            {
                Items =
                {
                    _assets
                }
            });
        }
    }
}
