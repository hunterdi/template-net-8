using Infrastructure.Behaviors.Repositories;

namespace Repository.Repositories.Postgres
{
    public interface IFileRepository : IBaseRepository<Domain.Entities.File, long>
    {
    }
}
