using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Infrastructure.Behaviors.MediatR.Pipelines
{
    public class RequestResponseLoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly ILogger _logger;

        public RequestResponseLoggingBehavior(ILogger<RequestResponseLoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestJson = JsonSerializer.Serialize(request);
            _logger.LogDebug($"REQUEST_LOG[REQUEST_RESPONSE_LOGGING_BEHAVIOR][REQUEST]:${requestJson}");

            var response = await next();

            var responseJson = JsonSerializer.Serialize(response);

            _logger.LogDebug($"RESPONSE_LOG[REQUEST_RESPONSE_LOGGING_BEHAVIOR][RESPONSE]:${responseJson}");

            return response;
        }
    }
}
