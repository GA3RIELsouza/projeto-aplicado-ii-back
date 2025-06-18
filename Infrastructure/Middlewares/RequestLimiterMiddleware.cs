using System.Net;
using Microsoft.Extensions.Caching.Memory;
using Projeto_Aplicado_II_API.Services;

namespace Projeto_Aplicado_II_API.Infrastructure.Middlewares
{
    public class RequestLimiterMiddleware(AuthService authService) : IMiddleware
    {
        private static int MaxRequestsPerSconed { get; } = 10;
        private static MemoryCache MemoryCache { get; } = new(new MemoryCacheOptions());

        private readonly AuthService _authService = authService;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var ipv4 = _authService.GetLoggedUserIpv4();

            if (string.IsNullOrWhiteSpace(ipv4))
            {
                await next(context);
                return;
            }

            var cacheKey = $"RateLimit_{ipv4}";
            var requestInfo = MemoryCache.GetOrCreate(cacheKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMilliseconds(1000);
                return new RequestCounter();
            });

            lock (requestInfo!)
            {
                requestInfo.Count++;
                if (requestInfo.Count > MaxRequestsPerSconed)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                    return;
                }
            }

            await next(context);
        }

        private class RequestCounter
        {
            public int Count { get; set; } = 0;
        }
    }
}
