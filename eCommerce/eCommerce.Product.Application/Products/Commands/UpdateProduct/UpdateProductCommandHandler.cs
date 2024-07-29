using eCommerce.Common.Exceptions;
using eCommerce.Product.Application.Abstractions;
using eCommerce.Product.Domain.Aggregates.ProductCategories;
using eCommerce.Product.Domain.Aggregates.Products;
using eCommerce.Product.Domain.Interfaces;

namespace eCommerce.Product.Application.Products.Commands.UpdateProduct
{
    internal sealed class UpdateProductCommandHandler(
        IProductRepository productRepository,
        ICategoryRepository CategoryRepository,
        IUnitOfWork unitOfWork) : ICommandHandler<UpdateProductCommand, Guid>
    {
        public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdWithCategoriesAsync(request.Id);
            if (product == null)
                throw new NotFoundException("პროდუქტი ვერ მოიძებნა");

            var categories = await CategoryRepository.GetByIdsAsync(request.CategoryIds);

            product.UpdateDetails(request.Name, request.Description, request.Price, request.StockQuantity);

            product.UpdateCategories(categories);

            productRepository.Update(product);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
