using FluentValidation;

namespace eCommerce.Product.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("პროდუქტის დასახელების შევსება სავალდებულოა");

            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage("პროდუქტის რაოდენობა უნდა იყოს 0-ზე მეტი ან ტოლი");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("პროდუქტის ფასი არავალიდურია");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("პროდუქტის აღწერის შევსება სავალდებულოა");

            RuleFor(x => x.CategoryIds)
                .NotEmpty()
                .WithMessage("კატეგორიის არჩევა სავალდებულოა");
        }
    }
}
