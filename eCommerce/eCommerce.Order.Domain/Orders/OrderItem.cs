using eCommerce.Order.Domain.Base;

namespace eCommerce.Order.Domain.Carts
{
    public class OrderItem : Entity
    {
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        public OrderItem(Guid id, Guid productId, string productName, int quantity, decimal unitPrice) 
            : base(id)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public decimal GetTotalPrice()
        {
            return Quantity * UnitPrice;
        }
    }
}
