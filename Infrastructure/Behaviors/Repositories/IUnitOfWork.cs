using Domain.Behaviors;
using MediatR;
using System.Threading;

namespace Infrastructure.Behaviors.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        TRepository GetRepository<TRepository, TEntity, TKey>() where TRepository : BaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey> where TKey : IComparable;
        Task RollbackAsync(CancellationToken cancellationToken = default);
        Task<T> TryExecuteAsync<T>(RequestHandlerDelegate<T> action) where T : notnull;
    }
}
