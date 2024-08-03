using MappingValidation.Models.Queries;
using Infrastructure.Behaviors.Services;

namespace Business.Services
{
    public interface IFileService : IBaseService<Domain.Entities.File, long>
    {
        Task<FileQuery> DownloadAsync(long id);
    }
}
