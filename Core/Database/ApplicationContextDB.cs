using MappingValidation.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Core.Database
{
    public sealed class ApplicationContextDB : DbContext
    {
        DbSet<Domain.Entities.File> files { get; set; }

        public ApplicationContextDB(DbContextOptions<ApplicationContextDB> options) : base(options)
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
