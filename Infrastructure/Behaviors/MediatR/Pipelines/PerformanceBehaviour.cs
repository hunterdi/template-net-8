using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Infrastructure.Behaviors.MediatR.Pipelines
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly ILogger _logger;
        public PerformanceBehaviour(ILogger<PerformanceBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var timer = Stopwatch.StartNew();
            
            var response = await next();
            timer.Stop();

            var elapsedMilliseconds = timer.ElapsedMilliseconds;

            _logger.LogInformation($"REQUEST[PERFORMANCE_BEHAVIOUR][END_TIME]:{elapsedMilliseconds}");

            return response;
        }
    }
}
