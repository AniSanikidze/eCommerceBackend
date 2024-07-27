using eCommerce.Order.Domain.Abstractions;
using eCommerce.Order.Domain.Carts;

namespace eCommerce.Order.Domain.Orders
{
    public sealed class Order : Entity
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public OrderStatus Status { get; private set; }
        public Guid CartId { get; private set; }
        public Cart Cart { get; private set; }

        //Todo: Address Value Object

        private Order() { }

        public Order(Guid id, Guid userId, DateTime orderDate, OrderStatus status) : base(id)
        {
            UserId = userId;
            OrderDate = orderDate;
            Status = status;
        }

        public static Order Create(Guid id, Guid userId, DateTime orderDate, OrderStatus status) : base(id)
        {
            //Todo: Create Order created domain event and then publish integration event
            return new Order(id, userId, orderDate, status);
        }

        public void SetStatus(OrderStatus status)
        {
            Status = status;
        }

        public decimal GetTotalPrice()
        {
            return Cart.Items.Sum(item => item.GetTotalPrice());
        }
    }

}
