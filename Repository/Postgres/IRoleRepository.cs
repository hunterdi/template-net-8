using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Repository.Postgres
{
    public interface IRoleRepository
    {
        Task<IReadOnlyList<IdentityRole<long>>> GetRoleByAsync(Expression<Func<IdentityRole<long>, bool>> expression);
        Task<IReadOnlyList<RoleClaim>> GetClaimsByAsync(Expression<Func<RoleClaim, bool>> expression);
    }
}
