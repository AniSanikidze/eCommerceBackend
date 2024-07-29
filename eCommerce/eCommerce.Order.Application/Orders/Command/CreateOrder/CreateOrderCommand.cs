﻿using eCommerce.Order.Application.Abstractions;

namespace eCommerce.Order.Application.Orders.Command.CreateOrder
{
    public record CreateOrderCommand(
        Guid CustomerId,
        PaymentDetailsRequestModel PaymentDetails) : ICommand<Guid>;
}
