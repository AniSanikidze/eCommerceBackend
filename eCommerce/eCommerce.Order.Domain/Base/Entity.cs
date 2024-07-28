namespace eCommerce.Order.Domain.Base
{
    public abstract class Entity
    {
        //ToDo: UnitOfWork?
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
