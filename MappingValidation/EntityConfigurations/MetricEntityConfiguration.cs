using MappingValidation.EntityConfigurations.Behaviors;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingValidation.EntityConfigurations
{
    public class MetricEntityConfiguration : EntityConfiguration<Domain.Entities.Metric, Guid>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Metric> builder)
        {
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Tags).IsRequired();
            builder.Property(e => e.Points).IsRequired(false);

            builder.HasMany(e => e.Points).WithOne(e => e.Metric).HasPrincipalKey(e => e.Id);
            builder.HasMany(e => e.Tags).WithOne(e => e.Metric).HasForeignKey(e => e.MetricId).HasPrincipalKey(e => e.Id);

            base.Configure(builder);
        }
    }
}
