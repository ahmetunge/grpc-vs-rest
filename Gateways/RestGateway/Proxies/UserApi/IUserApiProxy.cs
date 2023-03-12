using RestGateway.Proxies.UserApi.Models.Requests;
using RestGateway.Proxies.UserApi.Models.Responses;

namespace RestGateway.Proxies.UserApi
{
    public interface IUserApiProxy
    {
        Task<List<QueryUserBrokerageApiResponse>> QueryUserBrokerages(QueryUserBrokerageApiRequest userBrokerageApiRequest);
        Task<List<QueryUserBrokerageAccountApiResponse>> QueryUserBrokerageAccounts(QueryUserBrokerageAccountApiRequest userBrokerageAccountApiRequest);
    }
}
