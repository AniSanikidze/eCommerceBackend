using OrderEntity = eCommerce.Order.Domain.Orders.Order;
using eCommerce.Order.Persistence.Context;
using eCommerce.Order.Persistence.Repositories.Base;
using eCommerce.Order.Domain.Orders;

namespace eCommerce.Order.Persistence.Repositories
{
    public class OrderRepository : Repository<OrderEntity, Guid>, IOrderRepository
    {
        public OrderRepository(OrderDbContext context) : base(context)
        {
        }
    }
}
