using Infrastructure.Behaviors.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Behaviors.Middlewares.GlobalException
{
    public sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        private readonly ILogger _logger = logger;

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogInformation("EXCEPTION[GLOBAL_EXCEPTION_HANDLER]");

            var result = exception.GenerateResult(httpContext, _logger);

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = result.Status ?? throw new Exception("");

            await httpContext.Response.WriteAsJsonAsync(result, cancellationToken: cancellationToken).ConfigureAwait(false);

            return true;
        }
    }
}
