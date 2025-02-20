using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using FluentValidation;

namespace e_CommerceSystem.Bll.Validators;
public class UserDtoValidator : AbstractValidator<UserCreateDto>
{
    private readonly IUserRepo UserRepo;

    public UserDtoValidator(IUserRepo userRepo)
    {
        UserRepo = userRepo;
        RuleFor(u => u.Name).MaximumLength(50).WithMessage("Name must be less then 50");
        RuleFor(u => u.Email).MaximumLength(50).WithMessage("Name must be less then 50");
        RuleFor(u => u.Role).IsInEnum().WithMessage("Invalid user, Admin, Customer, Seller, Support, ContnentManager, WarehouseManager");
    }
}
