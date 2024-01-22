using Core.Database;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Repository.Common.Extensions;
using System.Linq.Expressions;

namespace Repository.Common.Behaviors
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey> where TKey : IComparable
    {
        protected readonly DbContext _dbContext;
        internal DbSet<TEntity> _set;

        public BaseRepository(ApplicationContextDB dbContext)
        {
            this._dbContext = dbContext;
            this._set = this._dbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await this._set.AddAsync(entity, cancellationToken);
            return entity;
        }

        public virtual async Task<TEntity[]> AddRangeAsync(TEntity[] entity, CancellationToken cancellationToken = default)
        {
            await this._set.AddRangeAsync(entity, cancellationToken);
            return entity;
        }

        public virtual Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            this._set.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            this._dbContext.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public virtual IEnumerable<TEntity> Specify(BaseSpecification<TEntity, TKey> spec)
        {
            var includes = spec.Includes.Aggregate(this._dbContext.Set<TEntity>().AsQueryable(), (current, include) => current.Include(include));

            return includes.Where(spec.Criteria).AsEnumerable();
        }

        public virtual IEnumerable<TEntity> SpecifyWithPagination(BaseSpecification<TEntity, TKey> spec, int pageSize = 10, int pageIndex = 0)
        {
            var includes = spec.Includes.Aggregate(this._dbContext.Set<TEntity>().AsQueryable(), (current, include) => current.Include(include));

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

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include)
        {
            return await this._set.Include(include).AnyAsync(predicate);
        }

        public virtual async Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var data = await _set.FirstOrDefaultAsync(predicate);
            if (includes.Any())
            {
                data = Include(includes).FirstOrDefault();
            }
            return data;
        }

        public virtual async Task<TEntity?> GetByIdAsync(TKey Id, params Expression<Func<TEntity, object>>[] includes)
        {
            var data = await _set.FindAsync(Id);
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

        public virtual async Task<PagedResponse<TEntity, TKey>> GetPagedAsync(PagingRequestModel<TEntity, TKey> request, Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> data = this.GetQueryable(predicate, includes);

            var result = await data.OrderByDynamic<TEntity, TKey>(request.OrderBy, request.OrderByDescending).PagingAsync<TEntity, TKey>(request.PageSize, request.PageNumber, cancellationToken);

            return result;
        }

        public async Task<int> SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            return await this._dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
