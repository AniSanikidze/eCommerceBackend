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
            var product = await productRepository.GetByIdAsync(request.Id);
            if (product == null || product.DeleteDate != null)
                throw new Exception("პროდუქტი ვერ მოიძებნა");

            productRepository.Delete(product);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
