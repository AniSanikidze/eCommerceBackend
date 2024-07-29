using eCommerce.Common.Exceptions;
using FluentValidation.Results;

namespace eCommerce.Order.Domain.Carts
{
    public class CartItem
    {
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        public CartItem(Guid productId, string productName, int quantity, decimal unitPrice)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public void IncrementQuantity() => Quantity++;
        public void DecrementQuantity()
        {
            if (Quantity - 1 <= 0)
                throw new ValidationException(
                    new List<ValidationFailure>{
                        new (nameof(Quantity), "არავალიდური პროდუქტის რაოდენობა")}
                    );
            Quantity--;
        }

        public decimal GetTotalPrice()
        {
            return Quantity * UnitPrice;
        }
    }
}
