
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Business.Services
{
    public interface IRoleService
    {
        Task<IReadOnlyList<RoleClaim>> GetClaimsAsync(IReadOnlyList<string> rolesName);
    }
}
