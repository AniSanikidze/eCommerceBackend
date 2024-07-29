using eCommerce.Order.Api.Controllers.Base;
using eCommerce.Order.Domain.Carts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Order.Api.Controllers
{
    [Route("api/carts")]
    [ApiController]
    public class CartController : BaseApiController
    {
        private readonly ICartRepository _cartRepository;
        public CartController(ISender mediator, ICartRepository cartRepository) : base(mediator)
        {
            _cartRepository = cartRepository;
        }

        /// <summary>
        /// Get cart details
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>Cart</returns>
        [HttpGet("{customerId:Guid}")]
        public async Task<Cart> GetCart(Guid customerId, CancellationToken cancellationToken) =>
            await _cartRepository.GetCartAsync(customerId, cancellationToken);

        [HttpPost("{customerId}/items")]
        public async Task<ActionResult> AddToCart(Guid customerId, CartItem item, CancellationToken cancellationToken)
        {
            await _cartRepository.AddToCartAsync(customerId, item, cancellationToken);
            return Ok();
        }

        [HttpDelete("{customerId}/items/{productId}")]
        public async Task<ActionResult> RemoveFromCart(Guid customerId, Guid productId, CancellationToken cancellationToken)
        {
            await _cartRepository.RemoveFromCartAsync(customerId, productId, cancellationToken);
            return Ok();
        }
    }
}
