using eCommerce.Product.Domain.Aggregates.ProductCategories;
using eCommerce.Product.Domain.Base;

namespace eCommerce.Product.Domain.Aggregates.Products
{
    public sealed class Product : Entity<Guid>
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
            SetPrice(price);
            SetStockQuantity(stockQuantity);
        }

        public void SetStockQuantity(int quantity)
        {
            if (quantity < 0)
                throw new ArgumentException("Stock quantity must be a positive integer.");

            StockQuantity = quantity;
        }

        public void SetPrice(decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("Invalid price");

            Price = price;
        }

        public void UpdateDetails(string name, string description, decimal price, int stockQuantity)
        {
            Name = name;
            Description = description;
            SetPrice(price);
            SetStockQuantity(stockQuantity);
        }

        public void UpdateCategories(IEnumerable<ProductCategory> categories)
        {
            ProductCategories.Clear();
            foreach (var category in categories)
            {
                ProductCategories.Add(category);
            }
        }

        public void AddCategory(ProductCategory category)
        {
            if (!ProductCategories.Contains(category))
                ProductCategories.Add(category);
        }

        public void RemoveCategory(ProductCategory category)
        {
            if (ProductCategories.Contains(category))
                ProductCategories.Remove(category);
        }
    }
}
