using FluentValidation;

namespace eCommerce.Product.Application.ProductCategories.Commands.CreateProductCategory
{
    public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
    {
        public CreateProductCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("პროდუქტის კატეგორიის დასახელების შევსება სავალდებულოა");
        }
    }
}
