using MappingValidation.Models.Queries;
using Service.Common.Behaviors;

namespace Service.Services
{
    public interface IFileService : IBaseService<Domain.Entities.File, Guid>
    {
        Task<FileViewModel> DownloadAsync(Guid id);
    }
}
