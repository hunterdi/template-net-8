using MappingValidation.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MappingValidation.Extensions
{
    public static class EntityMappingConfiguration
    {
        public static ModelBuilder AddModelsBuilders(this ModelBuilder modelBuilder)
        {
            //var typesToRegister = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
            //    .Where(x => typeof(IEntityConfig).IsAssignableFrom(x) && !x.IsAbstract).ToList();

            //if (typesToRegister.Any())
            //{
            //    foreach (var type in typesToRegister)
            //    {
            //        if (type.IsValueType)
            //        {
            //            dynamic configurationInstance = Activator.CreateInstance(type);
            //            modelBuilder.ApplyConfiguration(configurationInstance);
            //        }
            //    }
            //}

            //modelBuilder.ApplyConfiguration(new FileEntityConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.ApplyUtcDateTimeConverter();
            // https://github.dev/m-jovanovic/rally-simulator/blob/06959c8fd88fc8d00ede0e9bfdb1d5e4953d6a03/RallySimulator.Persistence/RallySimulatorDbContext.cs#L83#L90
            return modelBuilder;
        }
    }
}
