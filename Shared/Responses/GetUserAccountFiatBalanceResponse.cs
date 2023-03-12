namespace Shared.Responses
{
    public class GetUserAccountFiatBalanceResponse
    {
        public decimal BlockageAmount { get; set; }

        public decimal WithdrawableAmount { get; set; }

        public decimal CashInflowAmount { get; set; }

        public decimal CashOutflowAmount { get; set; }

        public List<YieldBalance> YieldBalances { get; set; }
    }

    public class YieldBalance
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }
    }
}
