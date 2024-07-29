using eCommerce.Product.Application.Abstractions;
using eCommerce.Product.Application.Products.Commands.DeleteProduct;
using eCommerce.Product.Domain.Aggregates.ProductCategories;
using eCommerce.Product.Domain.Interfaces;

namespace eCommerce.Product.Application.ProductCategories.Commands.DeleteCategory
{
    internal sealed class DeleteCategoryCommandHandler(
        ICategoryRepository CategoryRepository,
        IUnitOfWork unitOfWork)
        : ICommandHandler<DeleteCategoryCommand>
    {
        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var Category = await CategoryRepository.GetByIdAsync(request.Id, cancellationToken);
            if (Category == null || Category.DeleteDate != null)
                throw new Exception("პროდუქტის კატეგორია ვერ მოიძებნა");

            CategoryRepository.Delete(Category);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
