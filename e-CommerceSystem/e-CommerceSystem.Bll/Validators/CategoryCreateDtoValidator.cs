using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using e_CommerceSystem_.Dal.Entities;
using FluentValidation;

namespace e_CommerceSystem.Bll.Validators
{
    public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidator(ICategoryRepo categoryRepo)
        {
            RuleFor(c => c.Name).MaximumLength(50).WithMessage("Name must be less then 50");
            RuleFor(c => c.ParentCategoryId).GreaterThan(0).WithMessage("ParentCategoryId must be greater than 0.");
        }
    }
}
