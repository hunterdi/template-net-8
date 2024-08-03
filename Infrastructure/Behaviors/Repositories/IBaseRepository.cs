using Domain.Behaviors;
using System.Linq.Expressions;

namespace Infrastructure.Behaviors.Repositories
{
    public interface IBaseRepository<TEntity, TKey>: IDisposable where TEntity : BaseEntity<TKey> where TKey : IComparable
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity[]> AddRangeAsync(TEntity[] entity, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include, CancellationToken cancellationToken = default);
        Task BulkInsertAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken = default);
        Task BulkUpdateAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken = default);
        Task BulkDeleteAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken = default);
        Task BulkSaveChangeAsync(CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity?> GetByIdAsync(TKey Id, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes);
        Task<PagedResponse<TEntity>> GetPagedAsync(PagingRequestModel<TEntity, TKey> request, Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includes);
        Task<IReadOnlyList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includes);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        IEnumerable<TEntity> SpecifyWithPagination(BaseSpecification<TEntity, TKey> spec, int pageSize = 10, int pageIndex = 0);
        IEnumerable<TEntity> Specify(BaseSpecification<TEntity, TKey> spec);
        Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
    }
}
