namespace eCommerce.Payment.Domain.Abstractions
{
    public abstract class Entity
    {
        protected Entity()
        {
        }
        protected Entity(Guid id) { 
            Id = id;
        }
        public Guid Id { get; init; }
        public DateTime CreateDate { get; init; }
        public DateTime UpdateDate { get; init; }
        public DateTime DeleteDate { get; init; }
    }
}
