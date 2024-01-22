using Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Core.Common.Extensions
{
    public static class FormFileExtension
    {
        public static string GeneratePersistedFileName(this IFormFile formFile)
        {
            return $"{Guid.NewGuid()}-{formFile.FileName}";
        }

        public static FileExtensions GetExtension(this IFormFile formFile)
        {
            var extension =  Path.GetExtension(formFile.FileName);
            Enum.TryParse(extension.Replace(".", string.Empty).ToUpper(), out FileExtensions extensionEnum);
            return extensionEnum;
        }
    }
}
