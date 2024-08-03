using Autofac;
using Business.Handlers;
using Business.Services;
using MappingValidation.Models.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Business
{
    public sealed class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileService>().As<IFileService>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
            builder.RegisterType<RoleService>().As<IRoleService>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
            builder.RegisterType<JwtService>().As<IJwtService>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            builder.RegisterType<CreateUserHandler>().As<IRequestHandler<UserCreateCommand, IdentityResult>>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            base.Load(builder);
        }
    }
}
