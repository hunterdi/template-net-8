using Autofac;
using Service.Common.Behaviors;
using Service.Services;

namespace Service
{
    public sealed class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileService>().As<IBaseService<Domain.Entities.File, Guid>>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
            builder.RegisterType<FileService>().As<IFileService>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            base.Load(builder);
        }
    }
}
