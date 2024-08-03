using Domain.Entities;
using MappingValidation.EntityConfigurations.Behaviors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mapping.EntitiesConfiguration.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.FullName).IsRequired();
            builder.HasIndex(e => e.Email).IsUnique();
        }
    }
}
