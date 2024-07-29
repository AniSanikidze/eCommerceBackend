using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eCommerce.Product.Persistence.Interfaces
{
    public interface IAuditService
    {
        void ApplyAuditInformation(IEnumerable<EntityEntry> entries);
    }
}
