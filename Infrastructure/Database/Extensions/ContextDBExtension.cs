using Infrastructure.Behaviors.Extensions;
using Infrastructure.Behaviors.Services;
using Infrastructure.Database.Interceptors;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Database.Extensions
{
    public static class ContextDBExtension
    {
        public static IServiceCollection AddDatabaseContextConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var tenantService = services.GetService<TenantService>();

            services.FactoryDatabase(builder, tenantService);

            return services;
        }

        private static IServiceCollection FactoryDatabase(this IServiceCollection services, WebApplicationBuilder builder, TenantService tenant)
        {
            var connectionString = tenant.GetTenant()?.ConnectionString;
            var migrationsAssembly = typeof(PostgresDBContext).Assembly.GetName().Name;

            services.AddDbContextPool<PostgresDBContext>((options) =>
            {
                options.UseNpgsql(connectionString, x =>
                {
                    x.MigrationsAssembly(migrationsAssembly);
                    x.EnableRetryOnFailure(3);
                    x.CommandTimeout(120);
                });
                options.EnableSensitiveDataLogging(builder.Environment.IsDevelopment());
                options.EnableDetailedErrors(builder.Environment.IsDevelopment());
                options.UseLazyLoadingProxies();
                options.AddInterceptors(new SaveEntityInterceptor(tenant));
            });

            return services;
        }
    }
}
