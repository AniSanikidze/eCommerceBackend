namespace eCommerce.Order.Domain.Carts
{
    public class Cart
    {
        public Guid CustomerId { get; private set; }
        public List<CartItem> Items { get; private set; } = new List<CartItem>();

        private Cart()
        {

        }
        public Cart(Guid customerId, List<CartItem> items)
        {
            CustomerId = customerId;
            Items = items;
        }

        public void AddItem(CartItem cartItem)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == cartItem.ProductId);
            if (existingItem != null)
                existingItem.IncrementQuantity();
            else
                Items.Add(cartItem);
        }

        public void RemoveItem(Guid productId)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                if (item.Quantity > 1)
                    item.DecrementQuantity();
                else
                    Items.Remove(item);
            }
        }

        public decimal GetTotalPrice()
        {
            return Items.Sum(i => i.GetTotalPrice());
        }
    }
}
