namespace Domain.Common
{
    public sealed class TenantSettings
    {
        public required Guid DefaultId { get; set; }
        public required IEnumerable<Tenant> Tenants { get; set; }
        public required IEnumerable<Storage> Storages { get; set; }
    }

    public sealed class Tenant
    {
        public Guid Id { get; set; }
        public required string ConnectionString { get; set; }
        public required int DatabaseType { get; set; }
    }

    public sealed class Storage
    {
        public string? ConnectionString { get; set; }
        public required string Container { get; set; }
        public required int BlobType { get; set; }
    }
}
