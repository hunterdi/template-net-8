using Autofac;
using Domain.Behaviors;
using Domain.Entities;

namespace Domain
{
    public class DomainModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<IDataShaper<Entities.File>>().As<DataShaper<Entities.File>>().InstancePerLifetimeScope();
            //builder.RegisterType<IDataShaper<RoleClaim>>().As<DataShaper<RoleClaim>>().InstancePerLifetimeScope();
            //builder.RegisterType<IDataShaper<User>>().As<DataShaper<User>>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
