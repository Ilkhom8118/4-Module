using FluentValidation;
using Instagram.Bll.DTOs;

namespace Instagram.Bll.Validators;

public class PostCreateValidation : AbstractValidator<PostCreateDto>
{
    public PostCreateValidation()
    {
        RuleFor(c => c.PostType)
            .MaximumLength(20).MaximumLength(20)
            .WithMessage("Post type le must be less then 20")
            .NotEmpty().WithMessage("Post type can not be empty");

        RuleFor(c => c.AccountId)
            .GreaterThanOrEqualTo(1).WithMessage("Account id can not  be less then 1");
    }
}
