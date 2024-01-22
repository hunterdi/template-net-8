using Autofac;
using Repository.Common.Behaviors;
using Repository.Repositories.Postgres;

namespace Repository
{
    public class RepositoryModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileRepository>().As<IBaseRepository<Domain.Entities.File, Guid>>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
            builder.RegisterType<FileRepository>().As<IFileRepository>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            base.Load(builder);
        }
    }
}
