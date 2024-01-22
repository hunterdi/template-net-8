using MappingValidation.Models.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MappingValidation.Extensions
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
