using Core.Database;
using Repository.Common.Behaviors;

namespace Repository.Repositories.Postgres
{
    public interface IFileRepository : IBaseRepository<Domain.Entities.File, Guid>
    {
    }
}
