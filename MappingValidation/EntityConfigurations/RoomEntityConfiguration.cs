using MappingValidation.EntityConfigurations.Behaviors;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MappingValidation.EntityConfigurations
{
    public class RoomEntityConfiguration : EntityConfiguration<Domain.Entities.Room, long>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Room> builder)
        {
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.OwnerId).IsRequired();
            
            builder.HasOne(e => e.Owner).WithMany().HasForeignKey(e => e.OwnerId);
            builder.HasMany(e => e.Guests).WithMany();
            builder.HasMany(e => e.Messages).WithOne(e => e.Room).HasForeignKey(e => e.RoomId);

            base.Configure(builder);
        }
    }
}
