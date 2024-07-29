namespace eCommerce.Product.Domain.Base
{
    public abstract class BaseAuditableEntity<TId> : Entity<TId>, IBaseAuditableEntity
    {
        protected BaseAuditableEntity()
        {
        }
        protected BaseAuditableEntity(TId id) : base(id)
        {
        }
        public DateTime CreateDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
