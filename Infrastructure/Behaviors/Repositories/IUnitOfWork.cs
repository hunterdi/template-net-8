using Domain.Behaviors;
using MediatR;

namespace Infrastructure.Behaviors.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        TRepository GetRepository<TRepository, TEntity, TKey>() where TRepository : BaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey> where TKey : IComparable;
        Task<T> TryExecuteAsync<T>(RequestHandlerDelegate<T> action, CancellationToken cancellationToken = default);
    }
}
