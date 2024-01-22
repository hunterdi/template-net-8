using Core.Common.Providers;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace Core.Common.Extensions
{
    // https://www.youtube.com/watch?v=RRnGn8DDO18
    public static class ProviderExtension
    {
        public static IServiceCollection AddProviders(this IServiceCollection services)
        {
            services.AddHttpClient<IPClientService>()
        // ADDED RESILIENCE
        .AddPolicyHandler(
            Policy.Handle<HttpRequestException>()
            .WaitAndRetryAsync(3, retryAttemp => TimeSpan.FromSeconds(Math.Pow(2, retryAttemp)))
            .AsAsyncPolicy<HttpResponseMessage>())
        .AddPolicyHandler(
            Policy.Handle<HttpRequestException>()
            .CircuitBreakerAsync(2, TimeSpan.FromSeconds(30))
            .AsAsyncPolicy<HttpResponseMessage>());

            return services;
        }
    }
}
