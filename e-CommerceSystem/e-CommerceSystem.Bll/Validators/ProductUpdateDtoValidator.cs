using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using FluentValidation;

namespace e_CommerceSystem.Bll.Validators
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator(IProductRepo productRepo)
        {
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
            RuleFor(p => p.Stock).GreaterThan(0).WithMessage("Stock must be 0 or greater.");
        }
    }
}
