using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository.Common.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<TEntity> OrderByDynamic<TEntity, TKey>(this IQueryable<TEntity> query, string orderByMember = "CreatedAt", bool orderByDescending = true) where TEntity : BaseEntity<TKey> where TKey : IComparable
        {
            var queryElementTypeParam = Expression.Parameter(typeof(TEntity));
            var memberAccess = Expression.PropertyOrField(queryElementTypeParam, orderByMember);
            var keySelector = Expression.Lambda(memberAccess, queryElementTypeParam);

            var orderBy = Expression.Call(
                typeof(Queryable),
                orderByDescending ? "OrderByDescending" : "OrderBy",
                new Type[] {
                    typeof(TEntity),
                    memberAccess.Type
                },
                query.Expression,
                Expression.Quote(keySelector));

            return query.Provider.CreateQuery<TEntity>(orderBy);
        }

        public static async Task<PagedResponse<TEntity, TKey>> PagingAsync<TEntity, TKey>(this IQueryable<TEntity> query, int pageSize = 10, int pageNumber = 1, CancellationToken cancellationToken = default) where TEntity : BaseEntity<TKey> where TKey : IComparable
        {
            var totalRecords = query.Count();
            var result = pageSize > 0 && pageNumber > 0 ? await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken) : await query.ToListAsync(cancellationToken);
            return new PagedResponse<TEntity, TKey>(result, totalRecords, pageNumber, pageSize);
        }
    }
}
