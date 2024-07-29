using eCommerce.Common.Exceptions;
using eCommerce.Order.Domain.Carts;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace eCommerce.Order.Infrastructure.Services
{
    public class RedisCartRepository(IDistributedCache cache) : ICartRepository
    {
        public async Task RemoveFromCartAsync(Guid customerId, Guid productId, CancellationToken cancellationToken)
        {
            var cart = await GetCartAsync(customerId, cancellationToken);
            if (cart == null)
                throw new NotFoundException("კალათა ვერ მოიძებნა");

            cart.RemoveItem(productId);
            await SaveCartAsync(cart);
        }

        public async Task<Cart?> GetCartAsync(Guid customerId, CancellationToken cancellationToken)
        {
            string? cart = await cache.GetStringAsync(customerId.ToString(), cancellationToken);

            if (string.IsNullOrWhiteSpace(cart))
                return null;

            return JsonConvert.DeserializeObject<Cart>(cart);
        }

        public async Task AddToCartAsync(Guid customerId, CartItem item, CancellationToken cancellationToken)
        {
            var cart = await GetCartAsync(customerId, cancellationToken) ?? new Cart(customerId, new List<CartItem>());

            cart.AddItem(item);

            await SaveCartAsync(cart);
        }  
        
        private async Task SaveCartAsync(Cart cart) =>
            await cache.SetStringAsync(cart.CustomerId.ToString(), JsonConvert.SerializeObject(cart));
    }
}
