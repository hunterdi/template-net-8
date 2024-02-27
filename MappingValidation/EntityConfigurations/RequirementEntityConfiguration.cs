using MappingValidation.EntityConfigurations.Behaviors;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingValidation.EntityConfigurations
{
    public class RequirementEntityConfiguration : EntityConfiguration<Domain.Entities.Requirement, Guid>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Requirement> builder)
        {
            builder.Property(e => e.Type).IsRequired();
            builder.Property(e => e.Restriction).IsRequired();
            builder.Property(e => e.Metrics).IsRequired(false);

            builder.HasMany(e => e.Metrics);
            builder.HasOne(e => e.Restriction);

            base.Configure(builder);
        }
    }
}
