using MappingValidation.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MappingValidation.Extensions
{
    public static class EntityMappingConfiguration
    {
        public static ModelBuilder AddModelsBuilders(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            return modelBuilder;
        }
    }
}
