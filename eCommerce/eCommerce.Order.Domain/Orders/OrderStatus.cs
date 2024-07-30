namespace eCommerce.Order.Domain.Orders
{
    public enum OrderStatus
    {
        Created,
        Completed,
        StockValidationSucceded,
        StockValidationFailed,
        PaymentFailed
    }
}
