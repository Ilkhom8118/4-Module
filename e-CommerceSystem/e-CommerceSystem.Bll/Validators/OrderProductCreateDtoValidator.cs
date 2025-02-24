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
    public class OrderProductCreateDtoValidator:AbstractValidator<OrderProductCreateDto>
    {
        public OrderProductCreateDtoValidator(IOrderProductRepo orderProductRepo)
        {
            RuleFor(op => op.ProductId).GreaterThan(0).WithMessage("The Product ID must be greater than 0.");
            RuleFor(op => op.OrderId).GreaterThan(0).WithMessage("The Order ID must be greater than 0.");
            RuleFor(op => op.Quantity).GreaterThan(0).WithMessage("The product quantity must be greater than 0.");
            RuleFor(op => op.Price).GreaterThan(0).WithMessage("The product quantity must be greater than 0.");
        }
    }
}
