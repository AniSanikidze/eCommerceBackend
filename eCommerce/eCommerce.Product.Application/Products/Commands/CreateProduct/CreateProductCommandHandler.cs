using eCommerce.Product.Application.Abstractions;
using eCommerce.Product.Domain.Aggregates.ProductCategories;
using ProductEntity = eCommerce.Product.Domain.Aggregates.Products.Product;
using eCommerce.Product.Domain.Aggregates.Products;
using eCommerce.Product.Domain.Interfaces;

namespace eCommerce.Product.Application.Products.Commands.CreateProduct
{
    internal sealed class CreateProductCommandHandler(
        IProductRepository productRepository,
        IProductCategoryRepository productCategoryRepository,
        IUnitOfWork unitOfWork) : ICommandHandler<CreateProductCommand, Guid>
    {
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productCategories = await productCategoryRepository.GetByIdsAsync(request.ProductCategoryIds);
            var product = new ProductEntity(
                                    Guid.NewGuid(),
                                    request.Name,
                                    request.Description,
                                    request.Price,
                                    request.StockQuantity);

            foreach (var category in productCategories)
            {
                product.AddCategory(category);
            }

            await productRepository.AddAsync(product);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
