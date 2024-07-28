using eCommerce.Product.Application.Abstractions;
using eCommerce.Product.Application.Exceptions;
using eCommerce.Product.Domain.Aggregates.ProductCategories;
using eCommerce.Product.Domain.Interfaces;

namespace eCommerce.Product.Application.ProductCategories.Commands.UpdateProductCategory
{
    internal sealed class UpdateProductCategoryCommandHandler(
        IProductCategoryRepository productCategoryRepository,
        IUnitOfWork unitOfWork)
        : ICommandHandler<UpdateProductCategoryCommand, Guid>
    {
        public async Task<Guid> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = await productCategoryRepository.GetAsync(
                predicate: x => x.Id == request.Id && x.DeleteDate == null);

            if (productCategory == null)
                throw new NotFoundException("პროდუქტის კატეგორია ვერ მოიძებნა");

            productCategory.SetName(request.Name);
            productCategoryRepository.Update(productCategory);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return productCategory.Id;
        }
    }
}
