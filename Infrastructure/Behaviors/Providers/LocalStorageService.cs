using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;

namespace Infrastructure.Behaviors.Providers
{
    public sealed class LocalStorageService
    {
        public async Task<string> UploadAsync(string persistedFileName, IFormFile file, CancellationToken cancellationToken = default)
        {
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var filePath = Path.Combine(directory, persistedFileName);

            using var memoryStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(memoryStream, cancellationToken);
            memoryStream.Dispose();

            return filePath;
        }

        public async Task DownloadAsync(Domain.Entities.File fileEntity)
        {
            if (!File.Exists(fileEntity.Path))
            {
                throw new FileNotFoundException(fileEntity.Path);
            }

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileEntity.Path, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = await File.ReadAllBytesAsync(fileEntity.Path);

            fileEntity.Content = bytes;
            fileEntity.ContentType = contentType;
        }

        public void Delete(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }

            File.Delete(filePath);
        }
    }
}
