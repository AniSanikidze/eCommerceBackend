using eCommerce.Product.Application.Abstractions;
using eCommerce.Product.Application.Products.Commands.DeleteProduct;
using eCommerce.Product.Domain.Aggregates.ProductCategories;
using eCommerce.Product.Domain.Interfaces;

namespace eCommerce.Product.Application.ProductCategories.Commands.DeleteProductCategory
{
    internal sealed class DeleteProductCategoryCommandHandler(
        IProductCategoryRepository productCategoryRepository,
        IUnitOfWork unitOfWork)
        : ICommandHandler<DeleteProductCommand>
    {
        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productCategory = await productCategoryRepository.GetByIdAsync(request.Id);
            if (productCategory == null || productCategory.DeleteDate != null)
                throw new Exception("პროდუქტის კატეგორია ვერ მოიძებნა");

            productCategoryRepository.Delete(productCategory);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
