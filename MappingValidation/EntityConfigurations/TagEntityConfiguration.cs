using MappingValidation.EntityConfigurations.Behaviors;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingValidation.EntityConfigurations
{
    internal class TagEntityConfiguration : EntityConfiguration<Domain.Entities.Tag, Guid>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Tag> builder)
        {
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Value).IsRequired();

            builder.HasOne(e => e.Configuration).WithMany(e => e.Tags).HasForeignKey(e => e.ConfigurationId);

            base.Configure(builder);
        }
    }
}
