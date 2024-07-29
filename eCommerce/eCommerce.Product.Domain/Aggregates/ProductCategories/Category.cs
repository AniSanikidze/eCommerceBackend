using eCommerce.Product.Domain.Base;

namespace eCommerce.Product.Domain.Aggregates.ProductCategories
{
    public sealed class Category : BaseAuditableEntity<Guid>, IUpdateableEntity
    {
        public string Name { get; private set; }
        public DateTime UpdateDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public List<Products.Product> Products { get; private set; }

        // Constructor for EF Core
        private Category() { }

        public Category(Guid id, string name)
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
