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
    public class PointEntityConfiguration: EntityConfiguration<Domain.Entities.Point, Guid>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Point> builder)
        {
            builder.Property(e => e.Origin).IsRequired();
            builder.Property(e => e.ReferenceValue).IsRequired().HasDefaultValue(0);
            builder.Property(e => e.Value).IsRequired();

            builder.HasOne(e => e.Metric).WithMany(e => e.Points).HasForeignKey(e => e.MetricId);

            base.Configure(builder);
        }
    }
}
