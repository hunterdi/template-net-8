using Infrastructure.Database;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Seed.Seeds
{
    public class RoleSeeder
    {
        public static async Task<IReadOnlyList<IdentityRole<long>>> SeedAsync(PostgresDBContext context, RoleManager<IdentityRole<long>> roleManager)
        {
            using (context)
            {
                if (!roleManager.Roles.Any())
                {
                    var roles = Enum.GetNames(typeof(Roles));

                    foreach (var roleName in roles)
                    {
                        var role = new IdentityRole<long>(roleName);
                        await roleManager.CreateAsync(role);
                    }
                }

                var response = await context.Roles.ToListAsync();
                return response;
            }
        }
    }
}
