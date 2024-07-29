using eCommerce.Product.Application.Abstractions;
using eCommerce.Product.Application.Products.Models;

namespace eCommerce.Product.Application.Products.Commands.CreateProduct
{
    public record CreateProductCommand : ProductRequestModel, ICommand<Guid>
    {
        public CreateProductCommand(ProductRequestModel original) : base(original)
        {
        }
    }
}
