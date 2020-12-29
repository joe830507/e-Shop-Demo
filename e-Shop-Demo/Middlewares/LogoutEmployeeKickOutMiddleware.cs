using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Net.Http.Headers;
using System.Net;
using System.Threading.Tasks;

namespace e_Shop_Demo.Middlewares
{
    public class LogoutEmployeeKickOutMiddleware
    {
        public RequestDelegate _next { get; }

        public IDistributedCache DistributedCache { get; }
        public LogoutEmployeeKickOutMiddleware(RequestDelegate next, IDistributedCache distributedCache)
        {
            _next = next;
            DistributedCache = distributedCache;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var authorization = httpContext.Request.Headers[HeaderNames.Authorization].ToString();
            string[] splitAuthorization = string.IsNullOrEmpty(authorization) ? null : authorization.Split($" ");
            if (splitAuthorization.Length == 2 && !splitAuthorization.Equals("null"))
            {
                System.Console.WriteLine(splitAuthorization[1]);
                //await DistributedCache.SetStringAsync(splitAuthorization[1], "out");
                var isKickOut = !string.IsNullOrEmpty(await DistributedCache.GetStringAsync(splitAuthorization[1]));
                if (isKickOut)
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await httpContext.Response.WriteAsync("You are unauthorizated to use this function.");
                }
            }
            await _next(httpContext);
        }
    }
}
