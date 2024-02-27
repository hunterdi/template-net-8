using MappingValidation.EntityConfigurations.Behaviors;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingValidation.EntityConfigurations
{
    public class RestrictionEntityConfiguration : EntityConfiguration<Domain.Entities.Restriction, Guid>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Restriction> builder)
        {
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Attributes).IsRequired();
            builder.Property(e => e.Metric).IsRequired();

            builder.HasMany(e => e.Attributes);
            builder.HasOne(e => e.Metric);

            base.Configure(builder);
        }
    }
}
