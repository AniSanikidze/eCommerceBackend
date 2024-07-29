using eCommerce.Order.Domain.Interfaces;

namespace eCommerce.Order.Domain.Orders
{
    public interface IOrderRepository : IRepository<Order, Guid>
    {
    }
}
