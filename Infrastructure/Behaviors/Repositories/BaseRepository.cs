using Domain.Behaviors;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Infrastructure.Database;
using EFCore.BulkExtensions;
using Infrastructure.Behaviors.Extensions;

namespace Infrastructure.Behaviors.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IDisposable, IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey> where TKey : IComparable
    {
        protected readonly DbContext _dbContext;
        internal DbSet<TEntity> _set;
        private bool _disposed = false;

        public BaseRepository(PostgresDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _set = _dbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _set.AddAsync(entity, cancellationToken);
            return entity;
        }

        public virtual async Task<TEntity[]> AddRangeAsync(TEntity[] entity, CancellationToken cancellationToken = default)
        {
            await _set.AddRangeAsync(entity, cancellationToken);
            return entity;
        }

        public virtual Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _set.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public virtual IEnumerable<TEntity> Specify(BaseSpecification<TEntity, TKey> spec)
        {
            var includes = spec.Includes.Aggregate(_dbContext.Set<TEntity>().AsQueryable(), (current, include) => current.Include(include));

            return includes.Where(spec.Criteria).AsEnumerable();
        }

        public virtual IEnumerable<TEntity> SpecifyWithPagination(BaseSpecification<TEntity, TKey> spec, int pageSize = 10, int pageIndex = 0)
        {
            var includes = spec.Includes.Aggregate(_dbContext.Set<TEntity>().AsQueryable(), (current, include) => current.Include(include));

            return includes.Where(spec.Criteria).Skip(pageSize * pageIndex).Take(pageSize).AsEnumerable();
        }

        protected IEnumerable<TEntity> Include(params Expression<Func<TEntity, object>>[] includes)
        {
            IEnumerable<TEntity>? query = null;

            foreach (var include in includes)
            {
                query = _set.Include(include);
            }

            return query ?? _set;
        }

        public virtual async Task<IReadOnlyList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var data = predicate == null ? _set : _set.Where(predicate);
            if (includes.Any())
            {
                data = Include(includes).AsQueryable();
            }
            return await data.ToListAsync();
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include, CancellationToken cancellationToken = default)
        {
            return await _set.Include(include).AnyAsync(predicate, cancellationToken);
        }

        public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes)
        {
            var data = await _set.FirstOrDefaultAsync(predicate, cancellationToken);
            if (includes.Any())
            {
                data = Include(includes).FirstOrDefault();
            }
            return data;
        }

        public virtual async Task<TEntity?> GetByIdAsync(TKey Id, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes)
        {
            var data = await _set.FindAsync(Id, cancellationToken);
            if (includes.Any())
            {
                data = Include(includes).FirstOrDefault();
            }
            return data;
        }

        protected IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var data = predicate == null ? _set : _set.Where(predicate);
            if (includes.Any())
            {
                data = Include(includes).AsQueryable();
            }
            return data;
        }

        public virtual async Task<PagedResponse<TEntity>> GetPagedAsync(PagingRequestModel<TEntity, TKey> request, Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> data = GetQueryable(predicate, includes);

            var result = await data.OrderByDynamic<TEntity, TKey>(request.OrderBy, request.OrderByDescending).PagingAsync<TEntity, TKey>(request.PageSize, request.PageNumber, cancellationToken);

            return result;
        }

        public async Task<int> SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task BulkInsertAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _dbContext.BulkInsertAsync(entities, cancellationToken: cancellationToken);
        }

        public virtual async Task BulkUpdateAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _dbContext.BulkUpdateAsync(entities, cancellationToken: cancellationToken);
        }

        public virtual async Task BulkDeleteAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _dbContext.BulkDeleteAsync(entities, cancellationToken: cancellationToken);
        }

        public virtual async Task BulkSaveChangeAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.BulkSaveChangesAsync(cancellationToken: cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
