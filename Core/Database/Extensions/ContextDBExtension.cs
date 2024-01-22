using Core.Common.Providers;
using Core.Database.Interceptors;
using Domain.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//https://github.dev/elsa-workflows/elsa-guides/blob/f25a8813396d00ed7688e645a51aef304cefc50f/src/ElsaDemos.DocumentManagement/src/DocumentManagement.Persistence/Extensions/ServiceCollectionExtensions.cs#L11#L20

namespace Core.Database.Extensions
{
    // https://github.dev/elsa-workflows/elsa-guides/blob/f25a8813396d00ed7688e645a51aef304cefc50f/src/ElsaDemos.DocumentManagement/src/DocumentManagement.Persistence/Extensions/ServiceCollectionExtensions.cs#L11#L20
    // https://aspnano.com/build-multi-tenant-application-core-asp-net-7/
    // https://aspnano.com/asp-net-core-multi-tenant-app-multiple-databases-guide/
    public static class ContextDBExtension
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var serviceProvider = services.BuildServiceProvider();
            var tenantProvider = serviceProvider.GetRequiredService<TenantService>();

            services.FactoryDatabase(builder, tenantProvider);

            return services;
        }

        private static IServiceCollection FactoryDatabase(this IServiceCollection services, WebApplicationBuilder builder, TenantService tenant)
        {
            var connectionString = tenant.GetTenant()?.ConnectionString;

            services.AddDbContextPool<ApplicationContextDB>((options) =>
            {
                switch (tenant.GetDatabaseType())
                {
                    case DatabaseType.POSTGRES:
                        options.UseNpgsql(connectionString, x =>
                        {
                            x.MigrationsAssembly("RPGApi");
                            x.EnableRetryOnFailure(3);
                            x.CommandTimeout(120);
                        });
                        break;
                }
                options.EnableSensitiveDataLogging(builder.Environment.IsDevelopment());
                options.EnableDetailedErrors(builder.Environment.IsDevelopment());
                options.UseLazyLoadingProxies();
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.AddInterceptors(new SaveEntityInterceptor(tenant));
            });

            return services;
        }
    }
}
