using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using FluentValidation;

namespace e_CommerceSystem.Bll.Validators
{
    public class PaymentDtoValidator : AbstractValidator<PaymentDto>
    {
        public PaymentDtoValidator(IPaymentRepo paymentRepo)
        {
            RuleFor(p => p.Id).GreaterThan(0).WithMessage("The Payment ID must be greater than 0.");
            RuleFor(p => p.OrderId).GreaterThan(0).WithMessage("The Order ID must be greater than 0.");
            RuleFor(p => p.Amount).GreaterThan(0).WithMessage("The payment amount must be greater than 0.");
            RuleFor(payment => payment.StatusPayment).IsInEnum().WithMessage("Incorrect payment status.");
        }
    }
}
