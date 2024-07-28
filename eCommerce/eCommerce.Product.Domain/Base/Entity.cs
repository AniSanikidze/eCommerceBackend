namespace eCommerce.Product.Domain.Base
{
    public abstract class Entity<TId>
    {
        protected Entity()
        {
        }
        protected Entity(TId id) { 
            Id = id;
        }
        public TId Id { get; init; }
        public DateTime CreateDate { get; init; }
        public DateTime UpdateDate { get; init; }
        public DateTime DeleteDate { get; init; }
    }
}
