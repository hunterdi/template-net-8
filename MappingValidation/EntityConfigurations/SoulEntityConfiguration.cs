using MappingValidation.EntityConfigurations.Behaviors;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingValidation.EntityConfigurations
{
    public class SoulEntityConfiguration : EntityConfiguration<Domain.Entities.Soul, Guid>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Soul> builder)
        {
            builder.Property(e => e.Attributes).IsRequired();
            
            builder.HasMany(e => e.Attributes);
            
            base.Configure(builder);
        }
    }
}
