using InsufficientStockEvent = eCommerce.Common.Events.InsufficientStock;
using MassTransit;
using eCommerce.Order.Domain.Orders;
using eCommerce.Common.Exceptions;
using eCommerce.Order.Domain.Interfaces;

namespace eCommerce.Order.Application.Orders.Events.InsufficientStock
{
    public class InsufficientStockConsumer(IOrderRepository orderRepository, IUnitOfWork unitOfWork) : IConsumer<InsufficientStockEvent>
    {
        public async Task Consume(ConsumeContext<InsufficientStockEvent> context)
        {
            var @event = context.Message;

            var order = await orderRepository.GetAsync(x => x.Id == @event.OrderId);

            if (order == null) 
                throw new NotFoundException("ორდერი ვერ მოიძებნა");

            order.SetStatus(OrderStatus.StockValidationFailed);

            orderRepository.Update(order);

            await unitOfWork.SaveChangesAsync();
        }
    }
}
