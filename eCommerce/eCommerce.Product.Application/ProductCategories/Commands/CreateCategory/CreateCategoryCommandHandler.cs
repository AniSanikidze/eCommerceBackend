using eCommerce.Product.Application.Abstractions;
using eCommerce.Product.Application.Products.Commands.CreateProduct;
using eCommerce.Product.Domain.Aggregates.ProductCategories;
using eCommerce.Product.Domain.Interfaces;

namespace eCommerce.Product.Application.ProductCategories.Commands.CreateCategory
{
    internal sealed class CreateCategoryCommandHandler(
        ICategoryRepository CategoryRepository,
        IUnitOfWork unitOfWork)
        : ICommandHandler<CreateCategoryCommand, Guid>
    {
        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var Category = new Category(
                Guid.NewGuid(),
                request.Name);

            await CategoryRepository.AddAsync(Category);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Category.Id;
        }
    }
}
