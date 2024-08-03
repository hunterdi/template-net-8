using Infrastructure.Behaviors.Repositories;
using Infrastructure.Database;

namespace Repository.Repositories.Postgres
{
    public class FileRepository : BaseRepository<Domain.Entities.File, long>, IFileRepository
    {
        public FileRepository(PostgresDBContext dbContext) : base(dbContext)
        {
        }
    }
}
