using eCommerce.Common.Exceptions;
using eCommerce.Product.Application.Abstractions;
using eCommerce.Product.Domain.Aggregates.Products;
using eCommerce.Product.Domain.Interfaces;

namespace eCommerce.Product.Application.Products.Commands.DeleteProduct
{
    internal sealed class DeleteProductCommandHandler(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork) : ICommandHandler<DeleteProductCommand>
    {
        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id, cancellationToken);
            if (product == null || product.DeleteDate != null)
                throw new NotFoundException("პროდუქტი ვერ მოიძებნა");

            productRepository.Delete(product);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
