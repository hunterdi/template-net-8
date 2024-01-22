using Core.Database;
using Repository.Common.Behaviors;

namespace Repository.Repositories.Postgres
{
    public class FileRepository : BaseRepository<Domain.Entities.File, Guid>, IFileRepository
    {
        public FileRepository(ApplicationContextDB dbContext) : base(dbContext)
        {
        }
    }
}
