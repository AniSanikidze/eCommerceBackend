using FluentValidation;

namespace eCommerce.Product.Application.ProductCategories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("პროდუქტის კატეგორიის დასახელების შევსება სავალდებულოა");
        }
    }
}
