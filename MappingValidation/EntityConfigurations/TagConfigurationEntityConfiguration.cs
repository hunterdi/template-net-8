using Domain.Enums;
using MappingValidation.EntityConfigurations.Behaviors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingValidation.EntityConfigurations
{
    public class TagConfigurationEntityConfiguration : EntityConfiguration<Domain.Entities.TagConfiguration, Guid>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.TagConfiguration> builder)
        {
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.IsMandatory).IsRequired().HasDefaultValue(false);
            builder.Property(e => e.CastTo).IsRequired().HasDefaultValue(Domain.Enums.ValueType.STRING);

            base.Configure(builder);
        }
    }
}
