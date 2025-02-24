using e_CommerceSystem.Bll.DTOs;
using FluentValidation;

namespace e_CommerceSystem.Bll.Validators
{
    public class CartCreateDtoValidator : AbstractValidator<CartCreateDto>
    {
        public CartCreateDtoValidator()
        {
            RuleFor(c => c.UserId).GreaterThan(0).WithMessage("The Id must be greater than 0.");
        }
    }
}
