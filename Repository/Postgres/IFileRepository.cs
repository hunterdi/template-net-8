using Infrastructure.Behaviors.Repositories;

namespace Repository.Postgres
{
    public interface IFileRepository : IBaseRepository<Domain.Entities.File, long>
    {
    }
}
