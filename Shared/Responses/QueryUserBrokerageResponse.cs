namespace Shared.Responses
{
    public class QueryUserBrokerageResponse
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string ReferenceId { get; set; }

        public int BrokerageId { get; set; }
    }
}
