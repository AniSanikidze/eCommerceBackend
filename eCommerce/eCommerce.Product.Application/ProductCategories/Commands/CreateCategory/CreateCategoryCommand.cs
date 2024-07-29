using eCommerce.Product.Application.Abstractions;
using eCommerce.Product.Application.ProductCategories.Models;

namespace eCommerce.Product.Application.ProductCategories.Commands.CreateCategory
{
    public record CreateCategoryCommand : CategoryRequestModel, ICommand<Guid>
    {
        public CreateCategoryCommand(CategoryRequestModel original) : base(original)
        {
        }
    }
}