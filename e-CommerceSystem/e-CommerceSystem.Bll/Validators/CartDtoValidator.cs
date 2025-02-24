using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using FluentValidation;

namespace e_CommerceSystem.Bll.Validators
{
    public class CartDtoValidator : AbstractValidator<CartDto>
    {
        public CartDtoValidator(ICartRepo cartRepo)
        {
            RuleFor(c => c.UserId).GreaterThan(0).WithMessage("The ID must be greater than 0.");
            RuleFor(c => c.CartProducts).NotNull().WithMessage("The list of Products cannot be null.");
        }
    }
}
