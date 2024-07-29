namespace eCommerce.Order.Domain.Base
{
    public interface IUpdateableEntity
    {
        public DateTime UpdateDate { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
