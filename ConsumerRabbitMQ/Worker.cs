using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsumerRabbitMQ
{
    public sealed class Worker : IHostedService, IHostedLifecycleService
    {
        private readonly ILogger _logger;

        public Worker(ILogger<Worker> logger, IHostApplicationLifetime appLifetime)
        {
            _logger = logger;

            appLifetime.ApplicationStarted.Register(OnStarted);
            appLifetime.ApplicationStopping.Register(OnStopping);
            appLifetime.ApplicationStopped.Register(OnStopped);
        }

        public Task StartingAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("1. StartingAsync has been called.");

            return Task.CompletedTask;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("2. StartAsync has been called.");

            return Task.CompletedTask;
        }

        public Task StartedAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("3. StartedAsync has been called.");

            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            _logger.LogInformation("4. OnStarted has been called.");
        }

        private void OnStopping()
        {
            _logger.LogInformation("5. OnStopping has been called.");
        }

        public Task StoppingAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("6. StoppingAsync has been called.");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("7. StopAsync has been called.");

            return Task.CompletedTask;
        }

        public Task StoppedAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("8. StoppedAsync has been called.");

            return Task.CompletedTask;
        }

        private void OnStopped()
        {
            _logger.LogInformation("9. OnStopped has been called.");
        }
    }
}
