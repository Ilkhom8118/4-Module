using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using FluentValidation;

namespace e_CommerceSystem.Bll.Validators
{
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator(ICategoryRepo categoryRepo)
        {
            RuleFor(c => c.Name).MaximumLength(50).WithMessage("Name must be less then 50");
            RuleFor(c => c.ParentCategoryId).GreaterThan(0).When(c => c.ParentCategoryId.HasValue).WithMessage("The parent category ID must be positive.");
            RuleFor(c => c.SubCategories).NotNull().WithMessage("The list of subcategories cannot be null.");
            RuleFor(c => c.Products).NotNull().WithMessage("The list of Products cannot be null.");
        }
    }
}
