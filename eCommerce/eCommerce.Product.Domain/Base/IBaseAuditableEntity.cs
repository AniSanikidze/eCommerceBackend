namespace eCommerce.Product.Domain.Base
{
    public interface IBaseAuditableEntity
    {
        public DateTime CreateDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
