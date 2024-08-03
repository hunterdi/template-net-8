using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Behaviors.Middleware
{
    public class OperationCanceledMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public OperationCanceledMiddleware(
            RequestDelegate next,
            ILogger<OperationCanceledMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (TaskCanceledException)
            {
                _logger.LogError("REQUEST[CANCELLED]");
                context.Response.StatusCode = 409;
            }
            catch (OperationCanceledException)
            {
                _logger.LogError("REQUEST[CANCELLED]");
                context.Response.StatusCode = 409;
            }
        }
    }
}
