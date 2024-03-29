﻿using MappingValidation.EntityConfigurations.Behaviors;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingValidation.EntityConfigurations
{
    public class ActionEntityConfiguration : EntityConfiguration<Domain.Entities.Action, Guid>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Action> builder)
        {
            builder.Property(e => e.Name).IsRequired();
            //builder.Property(e => e.Requirement).IsRequired();
            //builder.Property(e => e.Metrics).IsRequired(false);
            
            //builder.HasMany(e => e.Metrics);
            //builder.HasOne(e => e.Requirement);

            base.Configure(builder);
        }
    }
}
