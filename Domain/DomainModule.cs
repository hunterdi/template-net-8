﻿using Autofac;
using Domain.Behaviors;
using Domain.Entities;

namespace Domain
{
    public class DomainModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }
    }
}
