using eCommerce.Order.Api.Controllers.Base;
using eCommerce.Order.Application.Orders.Command.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Order.Api.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : BaseApiController
    {
        public OrderController(ISender mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var orderId = await Mediator.Send(command);
            return Ok(orderId);
        }
    }
}
