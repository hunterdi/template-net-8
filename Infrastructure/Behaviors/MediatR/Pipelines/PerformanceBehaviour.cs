using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Infrastructure.Behaviors.MediatR.Pipelines
{
    public class PerformanceBehaviour<TRequest, TResponse>(ILogger<PerformanceBehaviour<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var timer = Stopwatch.StartNew();
            
            var response = await next();
            timer.Stop();

            var elapsedMilliseconds = timer.ElapsedMilliseconds;

            logger.LogInformation($"REQUEST[END_TIME]{elapsedMilliseconds}");

            return response;
        }
    }
}
