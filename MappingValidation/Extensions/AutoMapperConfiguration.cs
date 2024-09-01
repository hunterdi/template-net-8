using Microsoft.Extensions.DependencyInjection;

namespace MappingValidation.Extensions
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddMappersConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
