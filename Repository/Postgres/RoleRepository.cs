using Infrastructure.Database;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository.Postgres
{
    public class RoleRepository : IRoleRepository
    {
        protected readonly PostgresDBContext _dbContext;

        public RoleRepository(PostgresDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<IdentityRole<long>>> GetRoleByAsync(Expression<Func<IdentityRole<long>, bool>> expression)
        {
            var query = _dbContext.Roles.Where(expression);
            var response = await query.ToListAsync();

            return response;
        }

        public async Task<IReadOnlyList<RoleClaim>> GetClaimsByAsync(Expression<Func<RoleClaim, bool>> expression)
        {
            var query = _dbContext.RoleClaims.Where(expression);
            var response = await query.ToListAsync();

            return response;
        }
    }
}
