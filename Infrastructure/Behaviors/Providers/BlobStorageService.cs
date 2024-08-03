using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Azure;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Domain.Behaviors;
using Infrastructure.Behaviors.Services;

// https://github.dev/Daniel-Krzyczkowski/Pluralsight/blob/c46456d96f0999f29b4b2bc4b761686cfb14695a/ms-dev-azure-monitoring-and-logging/src/cars-island-web-api/CarsIsland.API/Core/DependencyInjection/StorageServiceCollectionExtensions.cs#L11#L20

namespace Infrastructure.Behaviors.Providers
{
    public sealed class BlobStorageService : IBlobStorageService
    {
        private readonly TenantService _tenantService;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly ILogger _log;

        public BlobStorageService(BlobServiceClient blobServiceClient,
                              TenantService tenantService,
                              ILogger<BlobStorageService> log)
        {
            _tenantService = tenantService
                    ?? throw new ArgumentNullException(nameof(tenantService));
            _blobServiceClient = blobServiceClient
                    ?? throw new ArgumentNullException(nameof(blobServiceClient));
            _log = log
                    ?? throw new ArgumentNullException(nameof(log));
        }

        private Storage GetStorage()
        {
            var tenantSettings = _tenantService.GetTenantSettings();
            return tenantSettings.Storages.First();
        }

        public async Task DeleteBlobIfExistsAsync(string blobName)
        {
            try
            {
                var container = await GetBlobContainer();
                var blockBlob = container.GetBlobClient(blobName);
                await blockBlob.DeleteIfExistsAsync();
            }
            catch (RequestFailedException ex)
            {
                _log.LogError($"Document {blobName} was not deleted successfully - error details: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DoesBlobExistAsync(string blobName)
        {
            try
            {
                var container = await GetBlobContainer();
                var blockBlob = container.GetBlobClient(blobName);
                var doesBlobExist = await blockBlob.ExistsAsync();
                return doesBlobExist.Value;
            }
            catch (RequestFailedException ex)
            {
                _log.LogError($"Document {blobName} existence cannot be verified - error details: {ex.Message}");
                throw;
            }
        }

        public async Task DownloadBlobIfExistsAsync(Stream stream, string blobName)
        {
            try
            {
                var container = await GetBlobContainer();
                var blockBlob = container.GetBlobClient(blobName);

                await blockBlob.DownloadToAsync(stream);

            }

            catch (RequestFailedException ex)
            {
                _log.LogError($"Cannot download document {blobName} - error details: {ex.Message}");
                if (ex.ErrorCode != "404")
                {
                    throw;
                }
            }
        }

        public async Task<string> GetBlobUrl(string blobName)
        {
            try
            {
                var container = await GetBlobContainer();
                var blob = container.GetBlobClient(blobName);

                string blobUrl = blob.Uri.AbsoluteUri;
                return blobUrl;
            }
            catch (RequestFailedException ex)
            {
                _log.LogError($"Url for document {blobName} was not found - error details: {ex.Message}");
                throw;
            }
        }

        public async Task<string> UploadBlobAsync(Stream stream, string blobName)
        {
            try
            {
                Debug.Assert(stream.CanSeek);
                stream.Seek(0, SeekOrigin.Begin);
                var container = await GetBlobContainer();

                BlobClient blob = container.GetBlobClient(blobName);
                await blob.UploadAsync(stream);
                return blob.Uri.AbsoluteUri;
            }

            catch (RequestFailedException ex)
            {
                _log.LogError($"Document {blobName} was not uploaded successfully - error details: {ex.Message}");
                throw;
            }
        }

        private async Task<BlobContainerClient> GetBlobContainer()
        {
            try
            {
                BlobContainerClient container = _blobServiceClient
                                .GetBlobContainerClient(GetStorage().Container);

                await container.CreateIfNotExistsAsync();

                return container;
            }
            catch (RequestFailedException ex)
            {
                _log.LogError($"Cannot find blob container: {GetStorage().Container} - error details: {ex.Message}");
                throw;
            }
        }

        public string GenerateSasTokenForContainer()
        {
            BlobSasBuilder builder = new BlobSasBuilder();
            builder.BlobContainerName = GetStorage().Container;
            builder.ContentType = "video/mp4";
            builder.SetPermissions(BlobAccountSasPermissions.Read);
            builder.StartsOn = DateTimeOffset.UtcNow;
            builder.ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(90);
            //var sasToken = builder
            //            .ToSasQueryParameters(new StorageSharedKeyCredential(_blobStorageServiceConfiguration.AccountName,
            //                                                                 _blobStorageServiceConfiguration.Key))
            //            .ToString();

            var sasToken = string.Empty;

            return sasToken;
        }
    }
}
