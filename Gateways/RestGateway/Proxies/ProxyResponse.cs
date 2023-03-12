using Microsoft.AspNetCore.Mvc;

namespace RestGateway.Proxies
{
    public class ProxyResponse<T> : ProxyResponse where T : class, new()
    {
        public T Data { get; set; }
    }

    public class ProxyResponse
    {
        public ProblemDetails ProblemDetails { get; set; }

        public bool HasError => ProblemDetails != null;
    }
}
