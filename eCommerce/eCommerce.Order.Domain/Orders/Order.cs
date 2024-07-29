using eCommerce.Order.Domain.Base;
using eCommerce.Order.Domain.Carts;

namespace eCommerce.Order.Domain.Orders
{
    public sealed class Order : BaseAuditableEntity<Guid>, IUpdateableEntity
    {
        public Guid UserId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public OrderStatus Status { get; private set; }
        public decimal TotalAmount { get; private set; } 
        public DateTime UpdateDate { get; set; }
        public Guid UpdatedBy { get; set; }

        public List<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();

        private Order() { }

        private Order(Guid id, Guid userId, DateTime orderDate, OrderStatus status) : base(id)
        {
            UserId = userId;
            OrderDate = orderDate;
            Status = status;
            SetTotalAmount();
        }

        public static Order Create(Guid id, Guid userId, DateTime orderDate, OrderStatus status)
        {
            //Todo: Create Order created domain event and then publish integration event
            return new Order(id, userId, orderDate, status);
        }

        public void SetStatus(OrderStatus status)
        {
            Status = status;
        }

        public void SetTotalAmount()
        {
            TotalAmount = OrderItems.Sum(item => item.GetTotalPrice());
        }
    }
}
