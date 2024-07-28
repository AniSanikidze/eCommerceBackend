using FluentValidation;

namespace eCommerce.Product.Application.ProductCategories.Commands.UpdateProductCategory
{
    public class UpdateProductCategoryCommandValidator : AbstractValidator<UpdateProductCategoryCommand>
    {
        public UpdateProductCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("პროდუქტის კატეგორიის დასახელების შევსება სავალდებულოა");
        }
    }
}
