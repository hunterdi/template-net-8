using MappingValidation.EntityConfigurations.Behaviors;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MappingValidation.EntityConfigurations
{
    public class FileEntityConfiguration: EntityConfiguration<Domain.Entities.File, long>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.File> builder)
        {
            builder.Property(e => e.Extension).IsRequired();
            builder.Property(e => e.Length).IsRequired();
            builder.Property(e => e.PersistedName).IsRequired();
            builder.Property(e => e.Path).IsRequired();
            builder.Property(e => e.RealName).IsRequired();
            builder.Ignore(e => e.ContentType);
            builder.Ignore(e => e.Content);
            
            base.Configure(builder);
        }
    }
}
