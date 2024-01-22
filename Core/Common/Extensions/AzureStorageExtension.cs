using Azure.Storage.Blobs;
using Core.Common.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Common.Extensions
{
    public static class AzureStorageExtension
    {
        public static IServiceCollection AddStorage(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var tenantProvider = serviceProvider.GetRequiredService<TenantService>();
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
