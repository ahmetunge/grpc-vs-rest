namespace Shared.Responses
{
    public class QueryUserAccountAssetBalanceResponse
    {
        public string Symbol { get; set; }

        public decimal Price { get; set; }

        public decimal TotalQuantity { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal AvailableQuantity { get; set; }

        public decimal AvailableAmount { get; set; }
    }
}
