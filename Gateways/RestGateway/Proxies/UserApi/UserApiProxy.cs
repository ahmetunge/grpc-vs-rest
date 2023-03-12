using RestGateway.Extensions;
using RestGateway.Proxies.UserApi.Models.Requests;
using RestGateway.Proxies.UserApi.Models.Responses;
using System.Text.Json;

namespace RestGateway.Proxies.UserApi
{
    public class UserApiProxy : IUserApiProxy
    {
        private readonly HttpClient _httpClient;

        public UserApiProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<QueryUserBrokerageAccountApiResponse>> QueryUserBrokerageAccounts(QueryUserBrokerageAccountApiRequest request)
        {
            string url = $"/api/user-brokerage-accounts?{request.ToQueryString()}";

            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(url);

            string responseContent = await httpResponseMessage.Content.ReadAsStringAsync();

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                List<QueryUserBrokerageAccountApiResponse> response = JsonSerializer.Deserialize<List<QueryUserBrokerageAccountApiResponse>>(responseContent);

                return response;
            }

            throw new Exception($"UserApi query user brokerage accounts failed. StatusCode: {(int)httpResponseMessage.StatusCode} Content: {responseContent}");
        }

        public async Task<List<QueryUserBrokerageApiResponse>> QueryUserBrokerages(QueryUserBrokerageApiRequest request)
        {
            string url = $"/api/user-brokerages?{request.ToQueryString()}";

            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(url);

            string responseContent = await httpResponseMessage.Content.ReadAsStringAsync();

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                List<QueryUserBrokerageApiResponse> response = JsonSerializer.Deserialize<List<QueryUserBrokerageApiResponse>>(responseContent);

                return response;
            }

            throw new Exception($"UserApi query user brokerages call failed. StatusCode: {(int)httpResponseMessage.StatusCode} Content: {responseContent}");
        }
    }
}
