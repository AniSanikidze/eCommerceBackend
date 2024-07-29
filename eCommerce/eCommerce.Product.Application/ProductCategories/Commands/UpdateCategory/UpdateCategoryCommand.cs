using eCommerce.Product.Application.Abstractions;
using eCommerce.Product.Application.ProductCategories.Models;

namespace eCommerce.Product.Application.ProductCategories.Commands.UpdateCategory
{
    public record UpdateCategoryCommand : CategoryRequestModel, ICommand<Guid>
    {
        public Guid Id { get; set; }
        public UpdateCategoryCommand(Guid id, CategoryRequestModel original) : base(original)
        {
            Id = id;
        }
    }
}