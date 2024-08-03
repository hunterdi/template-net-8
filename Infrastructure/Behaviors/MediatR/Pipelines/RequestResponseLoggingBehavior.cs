using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Infrastructure.Behaviors.MediatR.Pipelines
{
    public class RequestResponseLoggingBehavior<TRequest, TResponse>(ILogger<RequestResponseLoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestJson = JsonSerializer.Serialize(request);
            logger.LogDebug($"LOGGIN[REQUEST_RESPONSE_LOGGING_BEHAVIOR][REQUEST]:${requestJson}");

            var response = await next();
            
            var responseJson = JsonSerializer.Serialize(response);

            logger.LogDebug($"LOGGIN[REQUEST_RESPONSE_LOGGING_BEHAVIOR][RESPONSE]:${responseJson}");

            return response;
        }
    }
}
