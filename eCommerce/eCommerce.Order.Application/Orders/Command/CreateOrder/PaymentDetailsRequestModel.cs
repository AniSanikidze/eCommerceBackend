namespace eCommerce.Order.Application.Orders.Command.CreateOrder
{
    public record PaymentDetailsRequestModel(
        string CardNumber,
        string CardHolderName,
        DateTime ExpiryDate,
        string Cvv);
}
