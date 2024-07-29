using FluentValidation;

namespace eCommerce.Product.Application.ProductCategories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("პროდუქტის კატეგორიის დასახელების შევსება სავალდებულოა");
        }
    }
}
