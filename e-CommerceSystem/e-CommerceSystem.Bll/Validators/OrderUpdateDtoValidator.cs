﻿using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using FluentValidation;

namespace e_CommerceSystem.Bll.Validators;

public class OrderUpdateDtoValidator : AbstractValidator<OrderUpdateDto>
{
    public OrderUpdateDtoValidator(IOrderRepo orderRepo)
    {
        RuleFor(o => o.Id).GreaterThan(0).WithMessage("The Order ID must be greater than 0.");
        RuleFor(o => o.UserId).GreaterThan(0).WithMessage("The User ID must be greater than 0.");
        RuleFor(o => o.OrderTime).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("The order time cannot be in the future.");
        
    }
}
