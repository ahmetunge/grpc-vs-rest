namespace RestGateway.Proxies.AssetApi.Models.Enums
{
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

    public enum MarketSegment
    {
        Unknown = 0,

        BistStars = 1,

        BistMain = 2,

        BistSubMarket = 3,

        WatchList = 4,

        PreMarketTradingPlatform = 5,

        StructuredProductsAndFundMarket = 6,

        EquityMarketForQualifiedInvestors = 7
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
}
