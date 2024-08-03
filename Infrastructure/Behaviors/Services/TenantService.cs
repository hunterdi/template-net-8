using Domain.Behaviors;
using Microsoft.Extensions.Options;

namespace Infrastructure.Behaviors.Services
{
    public sealed class TenantService
    {
        private readonly TenantSettings _tenantSettings;

        public TenantService(IOptions<TenantSettings> tenantsOptions)
        {
            _tenantSettings = tenantsOptions.Value;
        }

        public Tenant GetTenant()
        {
            var result = _tenantSettings.Tenants.First() ?? throw new ArgumentNullException(nameof(_tenantSettings.Tenants));
            return result;
        }

        public TenantSettings GetTenantSettings()
        {
            return _tenantSettings;
        }
    }
}
