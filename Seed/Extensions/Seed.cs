using Infrastructure.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Seed.Seeds;

namespace Seed.Extensions
{
    public class Seed
    {
        public static async Task SeedDataAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<PostgresDBContext>() ?? throw new Exception("");
            var roleManage = serviceProvider.GetService<RoleManager<IdentityRole<long>>>() ?? throw new Exception("");
            var logger = serviceProvider.GetService<ILogger<Seed>>() ?? throw new Exception("");

            logger.LogInformation("SEED[START]");

            if (!context.Database.EnsureCreated())
            {
                await context.Database.MigrateAsync();
            }

            var roles = await RoleSeeder.SeedAsync(context, roleManage);
            var permissions = await PermissionSeeder.SeedAsync(context, roleManage, roles);

            await context.DisposeAsync();

            logger.LogInformation("SEED[END]");
        }
    }
}
