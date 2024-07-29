using eCommerce.Product.Application.Abstractions;
using eCommerce.Product.Application.Exceptions;
using eCommerce.Product.Domain.Aggregates.ProductCategories;
using eCommerce.Product.Domain.Interfaces;

namespace eCommerce.Product.Application.ProductCategories.Commands.UpdateCategory
{
    internal sealed class UpdateCategoryCommandHandler(
        ICategoryRepository CategoryRepository,
        IUnitOfWork unitOfWork)
        : ICommandHandler<UpdateCategoryCommand, Guid>
    {
        public async Task<Guid> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var Category = await CategoryRepository.GetAsync(
                predicate: x => x.Id == request.Id && x.DeleteDate == null);

            if (Category == null)
                throw new NotFoundException("პროდუქტის კატეგორია ვერ მოიძებნა");

            Category.SetName(request.Name);
            CategoryRepository.Update(Category);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Category.Id;
        }
    }
}
