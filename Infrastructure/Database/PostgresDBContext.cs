using Domain.Entities;
using MappingValidation.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public sealed class PostgresDBContext : IdentityDbContext<User, IdentityRole<long>, long, IdentityUserClaim<long>, IdentityUserRole<long>, IdentityUserLogin<long>, RoleClaim, IdentityUserToken<long>>
    {
        DbSet<Domain.Entities.File> Files { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<Room> Rooms { get; set; }

        public PostgresDBContext(DbContextOptions<PostgresDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddModelsBuilders();

            base.OnModelCreating(modelBuilder);
        }
    }
}
