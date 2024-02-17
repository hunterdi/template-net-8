using MappingValidation.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Core.Database
{
    public sealed class ApplicationContextDB : DbContext
    {
        DbSet<Domain.Entities.Ability> abilities { get; set; }
        DbSet<Domain.Entities.Action> actions { get; set; }
        DbSet<Domain.Entities.Attribute> attributes { get; set; }
        DbSet<Domain.Entities.Character> characters { get; set; }
        DbSet<Domain.Entities.File> files { get; set; }
        DbSet<Domain.Entities.Metric> metrics { get; set; }
        DbSet<Domain.Entities.Personality> personalties { get; set; }
        DbSet<Domain.Entities.Point> points { get; set; }
        DbSet<Domain.Entities.Race> races { get; set; }
        DbSet<Domain.Entities.Requirement> requirements { get; set; }
        DbSet<Domain.Entities.Restriction> restrictions { get; set; }
        DbSet<Domain.Entities.Skill> skills { get; set; }
        DbSet<Domain.Entities.Soul> souls { get; set; }
        DbSet<Domain.Entities.Tag> tags { get; set; }
        DbSet<Domain.Entities.TagConfiguration> tagConfigurations { get; set; }
        DbSet<Domain.Entities.Talent> talent { get; set; }
        DbSet<Domain.Entities.VirtualCalculation> virtualCalculations { get; set; }
        
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
