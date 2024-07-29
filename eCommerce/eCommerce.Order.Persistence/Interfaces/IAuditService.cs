using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eCommerce.Order.Persistence.Interfaces
{
    public interface IAuditService
    {
        void ApplyAuditInformation(IEnumerable<EntityEntry> entries);
    }
}
