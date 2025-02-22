using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using FluentValidation;

namespace e_CommerceSystem.Bll.Validators
{
    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator(IUserRepo userRepo)
        {
            RuleFor(u => u.Name).MaximumLength(50).WithMessage("Name must be less then 50");
            RuleFor(u => u.Email).MaximumLength(50).WithMessage("Email must be less then 50");
        }
    }
}
