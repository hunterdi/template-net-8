using Domain.Behaviors;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Behaviors.Extensions.Configurations
{
    public static class OptionConfigurationExtension
    {
        public static IServiceCollection AddOptionsConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.Configure<Domain.Behaviors.Providers>(builder.Configuration.GetSection("Providers"));
            services.Configure<TenantSettings>(builder.Configuration.GetSection("Tenant"));
            services.Configure<AuthenticationSettings>(builder.Configuration.GetSection("Authentication"));

            return services;
        }
    }
}
