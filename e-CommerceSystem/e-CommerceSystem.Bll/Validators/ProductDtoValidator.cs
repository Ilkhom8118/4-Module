using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using FluentValidation;

namespace e_CommerceSystem.Bll.Validators;

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator(IProductRepo productRepo)
    {
        RuleFor(p => p.Name).MaximumLength(50).WithMessage("Name must be less then 50");
        RuleFor(p => p.Description).MaximumLength(500).WithMessage("Description must be less then 500");
        RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
        RuleFor(p => p.Stock).GreaterThan(0).WithMessage("Stock must be 0 or greater.");
        RuleFor(p => p.CategoryId).GreaterThan(0).WithMessage("CategoryId must be greater than 0.");
    }
}
