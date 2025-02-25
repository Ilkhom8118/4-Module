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
    public class PaymentCreateDtoValidator:AbstractValidator<PaymentCreateDto>
    {
        public PaymentCreateDtoValidator(IPaymentRepo paymentRepo)
        {
            
            RuleFor(p => p.Amount).GreaterThan(0).WithMessage("The payment amount must be greater than 0.");
            RuleFor(payment => payment.StatusPayment).IsInEnum().WithMessage("Incorrect payment status.");
        }
    }
}
