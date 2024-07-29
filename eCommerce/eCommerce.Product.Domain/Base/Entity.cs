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
    }
}
