using eCommerce.Common.Events;
using eCommerce.Common.Exceptions;
using eCommerce.Order.Application.Abstractions;
using eCommerce.Order.Domain.Carts;
using eCommerce.Order.Domain.Interfaces;
using eCommerce.Order.Domain.Orders;
using Mapster;
using MassTransit;

namespace eCommerce.Order.Application.Orders.Command.CreateOrder
{
    public class CreateOrderCommandHandler(
        IOrderRepository orderRepository,
        ICartRepository cartRepository,
        IUnitOfWork unitOfWork,
        IPublishEndpoint publishEndpoint) : ICommandHandler<CreateOrderCommand, Guid>
    {
        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var cart = await cartRepository.GetCartAsync(request.CustomerId, cancellationToken);
            if (cart == null || !cart.Items.Any())
                throw new NotFoundException("პროდუქტები ვერ მოიძებნა");

            var order = Domain.Orders.Order.Create(
                Guid.NewGuid(),
                request.CustomerId,
                DateTime.Now,
                OrderStatus.Created
            );

            foreach (var cartItem in cart.Items)
            {
                order.OrderItems.Add(new Domain.Orders.OrderItem(
                    cartItem.ProductId,
                    order.Id,
                    cartItem.ProductName,
                    cartItem.Quantity,
                    cartItem.UnitPrice
                ));
            }
            order.SetTotalAmount();

            await orderRepository.AddAsync(order);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            await publishEndpoint.Publish(order.Adapt<OrderCreated>());

            return order.Id;
        }
    }
}
