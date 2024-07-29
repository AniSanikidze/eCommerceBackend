namespace eCommerce.Order.Domain.Carts
{
    public interface ICartRepository
    {
        Task<Cart?> GetCartAsync(Guid customerrId, CancellationToken cancellationToken);
        Task AddToCartAsync(Guid customerId, CartItem item, CancellationToken cancellationToken);
        Task RemoveFromCartAsync(Guid customerId, Guid productId, CancellationToken cancellationToken);
    }
}
