using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MappingValidation.EntityConfigurations.Behaviors
{
    public abstract class EntityConfiguration<TEntity, TKey>: IEntityConfig, IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity<TKey> where TKey : IComparable
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.HasKey(e => e.Id);

            builder.Property(e => e.IsVisible).HasDefaultValue(true).IsRequired();
            builder.Property(e => e.IsActive).HasDefaultValue(true).IsRequired();
            builder.Property(e => e.IsDeleted).HasDefaultValue(false).IsRequired();
            builder.Property(e => e.DeletedAt).HasDefaultValue(null).IsRequired(false);

            builder.HasQueryFilter(e => !e.IsDeleted && e.IsActive);
        }
    }
}
