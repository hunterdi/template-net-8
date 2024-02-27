using MappingValidation.EntityConfigurations.Behaviors;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingValidation.EntityConfigurations
{
    public class RaceEntityConfiguration : EntityConfiguration<Domain.Entities.Race, Guid>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Race> builder)
        {
            builder.Property(e => e.Name).IsRequired();
            
            base.Configure(builder);
        }
    }
}
