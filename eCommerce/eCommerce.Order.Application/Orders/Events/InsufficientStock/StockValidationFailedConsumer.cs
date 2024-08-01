using MassTransit;
using eCommerce.Order.Domain.Orders;
using eCommerce.Common.Exceptions;
using eCommerce.Common.Events;
using eCommerce.Order.Domain.Outbox;
using eCommerce.Order.Application.Common.Idempotence;
using eCommerce.Order.Domain.Interfaces;

namespace eCommerce.Order.Application.Orders.Events.InsufficientStock
{
    public class StockValidationFailedConsumer : IdempotentConsumerBase<StockValidationFailed>
    {
        private readonly IOrderRepository _orderRepository;
        public StockValidationFailedConsumer(IOrderRepository orderReposiotry,
            IConsumerOutboxMessageRepository consumerMessageRepository, IUnitOfWork unitOfWork) 
            : base(unitOfWork,consumerMessageRepository)
        {
            _orderRepository = orderReposiotry;
        }

        protected override async Task ProcessMessage(ConsumeContext<StockValidationFailed> context)
        {
            var @event = context.Message;
            var order = await _orderRepository.GetAsync(x => x.Id == @event.OrderId);

            if (order == null)
                throw new NotFoundException("ორდერი ვერ მოიძებნა");

            order.SetStatus(OrderStatus.StockValidationFailed);

            _orderRepository.Update(order);
        }
    }
}
