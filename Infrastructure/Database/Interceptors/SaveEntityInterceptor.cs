using Domain.Behaviors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Infrastructure.Behaviors.Services;

// https://www.milanjovanovic.tech/blog/how-to-use-ef-core-interceptors

namespace Infrastructure.Database.Interceptors
{
    public class SaveEntityInterceptor : SaveChangesInterceptor
    {
        private readonly TenantService _tenantProvider;

        public SaveEntityInterceptor(TenantService tenantProvider)
        {
            _tenantProvider = tenantProvider;
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            if (eventData.Context is null) return await ValueTask.FromResult(result);

            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                AuditEntity(entry);
            }

            var response = await base.SavingChangesAsync(eventData, result, cancellationToken);

            return response;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            if (eventData.Context is null) return result;

            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                AuditEntity(entry);
            }

            var response = base.SavingChanges(eventData, result);
            
            return response;
        }

        private static void AuditEntity(EntityEntry entry)
        {
            var entity = entry.Entity as IBaseEntity;

            switch (entry.State)
            {
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    if (entity != null)
                    {
                        entity.Deleted();
                    }
                    break;
                case EntityState.Unchanged:
                case EntityState.Modified:
                    if (entity != null) entity.Modified();
                    break;
                case EntityState.Added:
                    if (entity != null)
                    {
                        entity.Created();
                    }
                    break;
            }
        }
    }
}
