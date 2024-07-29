using eCommerce.Product.Application.Abstractions;
using eCommerce.Product.Application.Products.Models;

namespace eCommerce.Product.Application.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand : ProductRequestModel, ICommand<Guid>
    {
        public Guid Id { get; set; }
        public UpdateProductCommand(Guid id, ProductRequestModel original) : base(original)
        {
            Id = id;
        }
    }
}
