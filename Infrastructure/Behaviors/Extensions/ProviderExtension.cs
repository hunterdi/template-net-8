using Infrastructure.Behaviors.Providers;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace Infrastructure.Behaviors.Extensions
{
    public static class ProviderExtension
    {
        public static IServiceCollection AddProvidersConfiguration(this IServiceCollection services)
        {
            services.AddHttpClient<IpClientService>()
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

        public static T GetService<T>(this IServiceCollection services)  where T : class
        {
            var serviceProvider = services.BuildServiceProvider();
            var service = serviceProvider.GetRequiredService<T>();
            return service;
        }
    }
}
