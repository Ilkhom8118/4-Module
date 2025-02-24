using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_CommerceSystem.Bll.Validators
{
    public class CartProductUpdateDtoValidator:AbstractValidator<CartProductUpdateDto>
    {
        public CartProductUpdateDtoValidator(ICartProductRepo cartProductRepo)
        {
            RuleFor(cartProduct => cartProduct.Quantity)
                    .GreaterThan(0).WithMessage("The Quantity must be greater than 0.");
        }
    }
}
