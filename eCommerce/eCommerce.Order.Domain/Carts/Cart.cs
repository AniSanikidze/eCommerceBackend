using eCommerce.Order.Domain.Base;

namespace eCommerce.Order.Domain.Carts
{
    public class Cart : Entity
    {
        public Guid UserId { get; private set; }
        public List<CartItem> Items { get; private set; } = new List<CartItem>();

        public Cart(Guid id, Guid userId) : base(id)
        {
            UserId = userId;
        }

        public void AddItem(Guid productId, string productName, int quantity, decimal unitPrice)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.UpdateQuantity(quantity);
            }
            else
            {
                Items.Add(new CartItem(Guid.NewGuid(),productId, productName, quantity, unitPrice));
            }
        }

        public void RemoveItem(Guid productId)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                Items.Remove(item);
            }
        }

        public decimal GetTotalPrice()
        {
            return Items.Sum(i => i.GetTotalPrice());
        }
    }
}
