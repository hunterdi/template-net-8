
using MappingValidation.EntityConfigurations.Behaviors;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingValidation.EntityConfigurations
{
    public class CharacterEntityConfiguration : EntityConfiguration<Domain.Entities.Character, Guid>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Character> builder)
        {
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Age).IsRequired();
            builder.Property(e => e.Race).IsRequired();
            builder.Property(e => e.LifePoints).IsRequired();
            builder.Property(e => e.SoulsPoints).IsRequired();
            builder.Property(e => e.StaminaPoints).IsRequired();
            builder.Property(e => e.Personalities).IsRequired();
            builder.Property(e => e.Restrictions).IsRequired();
            builder.Property(e => e.Attributes).IsRequired();
            builder.Property(e => e.Skills).IsRequired(false);
            builder.Property(e => e.Souls).IsRequired();
            builder.Property(e => e.Talents).IsRequired(false);
            builder.Property(e => e.Actions).IsRequired(false);

            builder.HasOne(e => e.Race);
            builder.HasMany(e => e.Personalities);
            builder.HasMany(e => e.Restrictions);
            builder.HasMany(e => e.Attributes);
            builder.HasMany(e => e.Skills);
            builder.HasMany(e => e.Souls);
            builder.HasMany(e => e.Talents);
            builder.HasMany(e => e.Actions);

            base.Configure(builder);
        }
    }
}
