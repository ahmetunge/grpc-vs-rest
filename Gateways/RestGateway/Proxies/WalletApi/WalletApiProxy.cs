using Microsoft.AspNetCore.Mvc;
using RestGateway.Extensions;
using RestGateway.Proxies.WalletApi.Models.Requests;
using RestGateway.Proxies.WalletApi.Models.Responses;
using System.Text.Json;

namespace RestGateway.Proxies.WalletApi
{
    public class WalletApiProxy : IWalletApiProxy
    {
        private readonly HttpClient _httpClient;

        public WalletApiProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProxyResponse<GetUserAccountFiatBalanceApiResponse>> GetUserAccountFiatBalance(GetUserAccountFiatBalanceApiRequest request)
        {
            string url = $"/api/user-account-fiat-balance?{request.ToQueryString()}";

            HttpResponseMessage responseMessage = await _httpClient.GetAsync(url);

            string responseContent = await responseMessage.Content.ReadAsStringAsync();

            ProxyResponse<GetUserAccountFiatBalanceApiResponse> proxyResponse = new ProxyResponse<GetUserAccountFiatBalanceApiResponse>();

            if (responseMessage.IsSuccessStatusCode)
            {
                proxyResponse.Data = JsonSerializer.Deserialize<GetUserAccountFiatBalanceApiResponse>(responseContent);

                return proxyResponse;
            }

            proxyResponse.ProblemDetails = JsonSerializer.Deserialize<ProblemDetails>(responseContent);

            return proxyResponse;
        }

        public async Task<ProxyResponse<List<QueryUserAccountAssetBalanceApiResponse>>> QueryUserAccountAssetBalances(QueryUserAccountAssetBalanceApiRequest request)
        {
            string url = $"/api/user-account-asset-balances?{request.ToQueryString()}";

            HttpResponseMessage responseMessage = await _httpClient.GetAsync(url);

            string responseContent = await responseMessage.Content.ReadAsStringAsync();

            ProxyResponse<List<QueryUserAccountAssetBalanceApiResponse>> proxyResponse = new ProxyResponse<List<QueryUserAccountAssetBalanceApiResponse>>();

            if (responseMessage.IsSuccessStatusCode)
            {
                proxyResponse.Data = JsonSerializer.Deserialize<List<QueryUserAccountAssetBalanceApiResponse>>(responseContent);

                return proxyResponse;
            }

            proxyResponse.ProblemDetails = JsonSerializer.Deserialize<ProblemDetails>(responseContent);

            return proxyResponse;
        }
    }
}
