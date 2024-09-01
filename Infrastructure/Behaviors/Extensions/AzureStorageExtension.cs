using Azure.Storage.Blobs;
using Infrastructure.Behaviors.Providers;
using Infrastructure.Behaviors.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Behaviors.Extensions
{
    public static class AzureStorageExtension
    {
        public static IServiceCollection AddStorageConfiguration(this IServiceCollection services)
        {
            //var serviceProvider = services.BuildServiceProvider();
            //var tenantProvider = serviceProvider.GetRequiredService<TenantService>();
            
            var tenantProvider = services.GetService<TenantService>();
            var tenantSettings = tenantProvider.GetTenantSettings();
            var storage = tenantSettings.Storages.First();

            services.AddSingleton(provider => new BlobContainerClient(storage.ConnectionString, storage.Container));
            services.AddSingleton(factory => new BlobServiceClient(storage.ConnectionString));
            services.AddSingleton<IBlobStorageService, BlobStorageService>();
            services.AddSingleton<LocalStorageService>();

            return services;
        }
    }
}
