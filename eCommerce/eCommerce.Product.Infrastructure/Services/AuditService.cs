using eCommerce.Product.Application.Services;
using eCommerce.Product.Domain.Base;
using eCommerce.Product.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eCommerce.Product.Infrastructure.Services
{
    public class AuditService(IUserResolverService userResolverService) : IAuditService
    {
        public void ApplyAuditInformation(IEnumerable<EntityEntry> entries)
        {
            foreach (var entityEntry in entries)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added when entityEntry.Entity is IBaseAuditableEntity entry:
                        SetAuditDetailsForAddedEntity(entry);
                        break;

                    case EntityState.Modified when entityEntry.Entity is IUpdateableEntity entry:
                        SetAuditDetailsForModifiedEntity(entry);
                        break;

                    case EntityState.Deleted when entityEntry.Entity is IBaseAuditableEntity entry:
                        entityEntry.State = EntityState.Modified;
                        SoftDeleteEntity(entry);
                        break;
                }
            }
        }

        private void SetAuditDetailsForAddedEntity(IBaseAuditableEntity entity)
        {
            entity.CreatedBy = userResolverService.UserId.Value;
            entity.CreateDate = DateTime.Now;

            if (entity is IUpdateableEntity updateableEntity)
            {
                SetAuditDetailsForModifiedEntity(updateableEntity);
            }
        }

        private void SetAuditDetailsForModifiedEntity(IUpdateableEntity entity)
        {
            entity.UpdatedBy = userResolverService.UserId.Value;
            entity.UpdateDate = DateTime.Now;
        }

        private void SoftDeleteEntity(IBaseAuditableEntity entity)
        {
            entity.DeleteDate = DateTime.Now;
        }
    }
}
