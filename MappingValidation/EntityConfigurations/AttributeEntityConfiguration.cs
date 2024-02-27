using MappingValidation.EntityConfigurations.Behaviors;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingValidation.EntityConfigurations
{
    public class AttributeEntityConfiguration : EntityConfiguration<Domain.Entities.Attribute, Guid>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Attribute> builder)
        {
            builder.Property(e => e.BaseValue).IsRequired();
            builder.Property(e => e.Type).IsRequired();
            builder.Property(e => e.VariableValue).IsRequired(false);
            builder.Property(e => e.ModifiedValue).IsRequired(false);
            builder.Property(e => e.ModifiedMetrics).IsRequired(false);

            builder.HasMany(e => e.ModifiedMetrics);
            
            base.Configure(builder);
        }
    }
}

