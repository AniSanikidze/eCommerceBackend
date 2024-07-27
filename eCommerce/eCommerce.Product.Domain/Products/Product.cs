using eCommerce.Product.Domain.Abstractions;

namespace eCommerce.Product.Domain.Products
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public List<ProductCategory> ProductCategories { get; private set; }
        //TODO: image

        private Product() { }

        public Product(Guid id, string name, string description, decimal price, int stockQuantity)
            : base(id)
        {
            Name = name;
            Description = description;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public void UpdateStock(int quantity)
        {
            StockQuantity = quantity;
        }

        public void UpdatePrice(decimal price)
        {
            Price = price;
        }
    }
}
