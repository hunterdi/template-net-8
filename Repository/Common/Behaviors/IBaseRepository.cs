using Domain.Common;
using System.Linq.Expressions;

namespace Repository.Common.Behaviors
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : IBaseEntity<TKey> where TKey : IComparable
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity[]> AddRangeAsync(TEntity[] entity, CancellationToken cancellationToken = default);
        Task<TEntity?> GetByIdAsync(TKey Id, params Expression<Func<TEntity, object>>[] includes);
        Task<PagedResponse<TEntity, TKey>> GetPagedAsync(PagingRequestModel<TEntity, TKey> request, Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        Task<IReadOnlyList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includes);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        IEnumerable<TEntity> SpecifyWithPagination(BaseSpecification<TEntity, TKey> spec, int pageSize = 10, int pageIndex = 0);
        IEnumerable<TEntity> Specify(BaseSpecification<TEntity, TKey> spec);
        Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
    }
}
