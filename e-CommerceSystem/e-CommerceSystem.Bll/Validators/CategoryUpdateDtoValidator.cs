using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using FluentValidation;

namespace e_CommerceSystem.Bll.Validators
{
    public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator(ICategoryRepo categoryRepo)
        {
            RuleFor(c => c.Id).GreaterThan(0).WithMessage("The ID must be greater than 0.");
            RuleFor(c => c.Name).MaximumLength(50).WithMessage("Name must be less then 50");
            RuleFor(c => c.ParentCategoryId).GreaterThan(0).When(c => c.ParentCategoryId.HasValue).WithMessage("The parent category ID must be positive.");
        }
    }
}
