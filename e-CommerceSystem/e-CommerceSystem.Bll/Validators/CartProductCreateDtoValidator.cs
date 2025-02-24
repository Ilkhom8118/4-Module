using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using FluentValidation;

namespace e_CommerceSystem.Bll.Validators
{
    public class CartProductCreateDtoValidator:AbstractValidator<CartProductCreateDto>
    {
        public CartProductCreateDtoValidator(ICartProductRepo cartProductRepo)
        {
            RuleFor(cartProduct => cartProduct.CartId)
                    .GreaterThan(0).WithMessage("The CartId must be greater than 0.");
            RuleFor(cartProduct => cartProduct.ProductId)
                    .GreaterThan(0).WithMessage("The ProductId must be greater than 0.");
            RuleFor(cartProduct => cartProduct.Quantity)
                    .GreaterThan(0).WithMessage("The Quantity must be greater than 0.");
        }
    }
}
