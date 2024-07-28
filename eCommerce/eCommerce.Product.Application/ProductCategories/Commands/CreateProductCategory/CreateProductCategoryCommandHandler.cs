using eCommerce.Product.Application.Abstractions;
using eCommerce.Product.Application.Products.Commands.CreateProduct;
using eCommerce.Product.Domain.Aggregates.ProductCategories;
using eCommerce.Product.Domain.Interfaces;

namespace eCommerce.Product.Application.ProductCategories.Commands.CreateProductCategory
{
    internal sealed class CreateProductCategoryCommandHandler(
        IProductCategoryRepository productCategoryRepository,
        IUnitOfWork unitOfWork)
        : ICommandHandler<CreateProductCommand, Guid>
    {
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productCategory = new ProductCategory(
                Guid.NewGuid(),
                request.Name);

            await productCategoryRepository.AddAsync(productCategory);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return productCategory.Id;
        }
    }
}
