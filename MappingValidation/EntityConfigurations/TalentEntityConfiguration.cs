using MappingValidation.EntityConfigurations.Behaviors;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingValidation.EntityConfigurations
{
    public class TalentEntityConfiguration : EntityConfiguration<Domain.Entities.Talent, Guid>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Talent> builder)
        {
            builder.Property(e => e.Name).IsRequired();
            //builder.Property(e => e.Requirement).IsRequired();
            //builder.Property(e => e.Metrics).IsRequired();

            builder.HasMany(e => e.Metrics);
            builder.HasOne(e => e.Requirement);

            base.Configure(builder);
        }
    }
}
