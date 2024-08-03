using Infrastructure.Database;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Seed.Seeds
{
    public class PermissionSeeder
    {
        public static async Task<IReadOnlyList<IdentityRoleClaim<long>>> SeedAsync(PostgresDBContext context, RoleManager<IdentityRole<long>> roleManager, IReadOnlyList<IdentityRole<long>> roles)
        {
            if (!context.RoleClaims.Any())
            {
                foreach (var role in roles)
                {
                    var modules = Enum.GetNames(typeof(Module));

                    foreach (var moduleName in modules)
                    {
                        var permissions = Enum.GetNames(typeof(Permission));

                        foreach (var permissionName in permissions)
                        {
                            await roleManager.AddClaimAsync(role, new Claim(ClaimTypes.AuthenticationMethod, $"{role.Name}.{moduleName}.{permissionName}"));
                        }
                    }
                }
            }
            var response = await context.RoleClaims.ToListAsync();
            return response;
        }
    }
}
