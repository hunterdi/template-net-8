using Domain.Entities;
using MappingValidation.EntityConfigurations.Behaviors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MappingValidation.EntityConfigurations
{
    public class RoleClaimEntityConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.Property(e => e.IsEnable).HasDefaultValue(true).IsRequired();
        }
    }
}
