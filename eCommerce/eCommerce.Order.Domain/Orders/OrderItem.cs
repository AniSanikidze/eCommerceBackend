namespace eCommerce.Order.Domain.Orders
{
    public class OrderItem
    {
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        public OrderItem(Guid productId, Guid orderId, string productName, int quantity, decimal unitPrice) 
        {
            OrderId = orderId;
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
