using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuthenticationService.Middlewares
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LogMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;   
        }

        public async Task Invoke(HttpContext httpContext)
        {
            LogRemoteIpAddress(httpContext);

            await _next(httpContext);
        }

        public void LogRemoteIpAddress(HttpContext httpContext)
        {
            var remoteIpAddress = httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            _logger.WriteEvent($"Request was received from {remoteIpAddress}");
        }
    }
}
