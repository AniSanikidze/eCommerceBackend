namespace eCommerce.Product.Domain
{
    public sealed class ProductCategory
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Product> Products { get; private set; }

        // Constructor for EF Core
        private ProductCategory() { }

        public ProductCategory(Guid id, string name, string description)
        {
            Id = id;
            SetName(name);
            SetDescription(description);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Category name cannot be empty.");
            }
            Name = name;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }
    }

}
