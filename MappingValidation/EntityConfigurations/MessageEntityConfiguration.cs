using MappingValidation.EntityConfigurations.Behaviors;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MappingValidation.EntityConfigurations
{
    public class MessageEntityConfiguration: EntityConfiguration<Domain.Entities.Message, long>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Message> builder)
        {
            builder.Property(e => e.OwnerId).IsRequired();
            builder.Property(e => e.RoomId).IsRequired();
            builder.Property(e => e.Command).IsRequired();

            builder.HasOne(e => e.Owner).WithMany().HasForeignKey(e => e.OwnerId);
            builder.HasOne(e => e.Room).WithMany().HasForeignKey(e => e.RoomId);

            base.Configure(builder);
        }
    }
}
