using FluentValidation;
using Infrastructure.Behaviors.MediatR.Pipelines;
using Infrastructure.Behaviors.Middlewares.GlobalException;
using Infrastructure.Behaviors.Services;
using Infrastructure.Database.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using MappingValidation.Extensions;

namespace Infrastructure.Behaviors.Extensions.Configurations
{
    public static class ServiceCollectionConfigurationExtension
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();
            services.AddOptionsConfiguration(builder);
            services.AddLocalization();
            services.AddHttpContextAccessor();
            services.AddProvidersConfiguration();
            services.AddScoped<TenantService>();
            services.AddAuthenticationConfiguration();
            services.AddDatabaseContextConfiguration(builder);
            services.AddMappersConfiguration();
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMediatR(e =>
            {
                e.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
                e.AddOpenBehavior(typeof(PerformanceBehaviour<,>));
                e.AddOpenBehavior(typeof(RequestResponseLoggingBehavior<,>));
                e.AddOpenBehavior(typeof(ValidationBehavior<,>));
                e.AddOpenBehavior(typeof(SaveChangeBehavior<,>));
            });

            services.AddStorageConfiguration();
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 512 * 1024 * 1024;
                options.BufferBodyLengthLimit = 512 * 1024 * 1024;
            });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerConfiguration();
            return services;
        }
    }
}
