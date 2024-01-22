using Domain.Common;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

// https://juldhais.net/how-to-get-client-ip-address-and-location-information-in-asp-net-core-c2bb50e689c3

namespace Core.Common.Providers
{
    public sealed class TenantService
    {
        private const string TENANT_ID_HEADER_NAME = "X-TenantId";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TenantSettings _tenantSettings;
        private readonly IPClientService _iPAPIClientProvider;

        public TenantService(
            IHttpContextAccessor httpContextAccessor,
            IOptions<TenantSettings> tenantsOptions,
            IPClientService iPAPIClientProvider)
        {
            _iPAPIClientProvider = iPAPIClientProvider;
            _httpContextAccessor = httpContextAccessor;
            _tenantSettings = tenantsOptions.Value;
        }

        public Guid GetTenantId()
        {
            var header = _httpContextAccessor.HttpContext?.Request.Headers.SingleOrDefault(e => e.Key == TENANT_ID_HEADER_NAME);
            var headerValue = header.GetValueOrDefault().Value.ToString();

            if (!header.HasValue) headerValue = _tenantSettings.DefaultId.ToString();

            var tenantId = headerValue;
            var result = Guid.Parse(tenantId);

            return result;
        }

        public Tenant? GetTenant()
        {
            var result = _tenantSettings.Tenants.Single(t => t.Id == GetTenantId());
            return result;
        }

        public DatabaseType GetDatabaseType()
        {
            var tenant = GetTenant();

            if (tenant == null) throw new Exception("");

            var result = Enum.Parse<DatabaseType>(tenant.DatabaseType.ToString());

            return result;
        }

        public async Task<IpApiProviderResponse?> GetLocationAsync(CancellationToken cancellationToken = default)
        {
            var ipAddress = _httpContextAccessor.HttpContext?.GetServerVariable("HTTP_X_FORWARDED_FOR") ?? _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
            var ipAddressWithoutPort = ipAddress?.Split(':')[0];
            var result = await _iPAPIClientProvider.GetAsync(ipAddressWithoutPort, cancellationToken);

            return result;
        }

        public TenantSettings GetTenantSettings()
        {
            return _tenantSettings;
        }
    }
}
