using Domain.Behaviors;
using Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Behaviors.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly PostgresDBContext _dbContext;
        private bool _disposed = false;
        private readonly ILogger _logger;
        private IDbContextTransaction? _transaction = null;

        public UnitOfWork(PostgresDBContext dbContext, ILogger<UnitOfWork> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<T> TryExecuteAsync<T>(RequestHandlerDelegate<T> action) where T : notnull
        {
            var _strategy = _dbContext.Database.CreateExecutionStrategy();

            if (_strategy == null) throw new ArgumentException();

            var result = await _strategy.ExecuteAsync<T>(async () =>
            {
                await BeginTransactionAsync();
                var actionResult = await action();
                await SaveChangesAsync();
                await CommitAsync();
                return actionResult;
            });

            return result;
        }

        private async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken) ?? throw new ArgumentNullException();
        }

        private async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction == null) throw new ArgumentNullException("CommitAsync");

            await _transaction.CommitAsync(cancellationToken);
        }

        private async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction == null) throw new ArgumentNullException("RollbackAsync");

            await _transaction.RollbackAsync(cancellationToken);
        }

        public TRepository GetRepository<TRepository, TEntity, TKey>() where TRepository : BaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey> where TKey : IComparable
        {
            return (Activator.CreateInstance(typeof(TRepository), new Object[] { _dbContext }) as TRepository) ?? throw new ArgumentNullException(nameof(TRepository));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _transaction?.Dispose();
                    _dbContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
