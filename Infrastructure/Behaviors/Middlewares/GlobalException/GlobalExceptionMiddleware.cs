using Infrastructure.Behaviors.Extensions;
using Infrastructure.Behaviors.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Behaviors.Middlewares.GlobalException
{
    public sealed class GlobalExceptionMiddleware(RequestDelegate next, IUnitOfWork unitOfWork, ILogger<GlobalExceptionMiddleware> logger)
    {
        private readonly ILogger _logger = logger;
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
                await unitOfWork.RollbackAsync();
                unitOfWork.Dispose();
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";

            _logger.LogInformation("EXCEPTION[GLOBAL_EXCEPTION_MIDDLEWARE]");

            var result = exception.GenerateResult(httpContext, _logger);
            httpContext.Response.StatusCode = result.Status ?? throw new Exception("");

            await httpContext.Response.WriteAsJsonAsync(result);
        }
    }
}
