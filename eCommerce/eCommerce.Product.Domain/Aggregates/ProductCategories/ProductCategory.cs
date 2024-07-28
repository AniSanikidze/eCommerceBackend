using eCommerce.Product.Domain.Base;

namespace eCommerce.Product.Domain.Aggregates.ProductCategories
{
    public sealed class ProductCategory : Entity<Guid>
    {
        public string Name { get; private set; }
        public List<Products.Product> Products { get; private set; }

        // Constructor for EF Core
        private ProductCategory() { }

        public ProductCategory(Guid id, string name)
        {
            Id = id;
            SetName(name);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Category name cannot be empty.");
            }
            Name = name;
        }
    }

}
