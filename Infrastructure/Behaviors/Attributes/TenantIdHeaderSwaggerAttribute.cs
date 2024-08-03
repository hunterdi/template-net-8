using Domain.Behaviors;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Infrastructure.Behaviors.Attributes
{
    public class TenantIdHeaderSwaggerAttribute : IOperationFilter
    {
        private readonly TenantSettings _tenantSettings;
        public TenantIdHeaderSwaggerAttribute(IOptions<TenantSettings> tenantsOptions)
        {
            _tenantSettings = tenantsOptions.Value;
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "X-TenantId",
                In = ParameterLocation.Header,
                Required = true,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString(_tenantSettings.DefaultId.ToString()),
                },
            });
        }
    }
}
