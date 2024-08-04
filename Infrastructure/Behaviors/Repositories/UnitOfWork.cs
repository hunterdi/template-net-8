using Domain.Behaviors;
using Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System.Transactions;

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

        public async Task<T> TryExecuteAsync<T>(RequestHandlerDelegate<T> action, CancellationToken cancellationToken = default)
        {
            try
            {
                var _strategy = _dbContext.Database.CreateExecutionStrategy();

                if (_strategy == null) throw new ArgumentException();

                var result = await _strategy.ExecuteAsync<T>(async () =>
                {
                    await BeginTransactionAsync(cancellationToken);
                    var actionResult = await action();
                    await SaveChangesAsync(cancellationToken);
                    await CommitAsync(cancellationToken);
                    return actionResult;
                });

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("TRANSACTION[UNITOFWORK][ERROR]");

                await RollbackAsync(cancellationToken);
                throw new TransactionException(ex.Message);
            }
            finally
            {
                _logger.LogInformation("TRANSACTION[UNITOFWORK][FINISHING]");
            }
        }

        private async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("TRANSACTION[UNITOFWORK][START]");

            _transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken) ?? throw new ArgumentNullException();
        }

        private async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction == null) throw new ArgumentNullException("CommitAsync");

            await _transaction.CommitAsync(cancellationToken);

            _logger.LogInformation("TRANSACTION[UNITOFWORK][COMMITED]");
        }

        private async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        private async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction == null) throw new ArgumentNullException("RollbackAsync");

            await _transaction.RollbackAsync(cancellationToken);

            _logger.LogInformation("TRANSACTION[UNITOFWORK][ROLLBACKED]");
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
            _logger.LogInformation("TRANSACTION[UNITOFWORK][DISPOSED]");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
