using AutoMapper;
using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using e_CommerceSystem_.Dal.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace e_CommerceSystem.Bll.Services;

public class UserService : IUserService
{
    private readonly IUserRepo UserRepo;
    private readonly IValidator<UserCreateDto> UserCreateDtoValidator;
    private readonly IValidator<UserUpdateDto> UserUpdateDtoValidator;
    private readonly IMapper Mapper;
    public UserService(IUserRepo userRepo, IValidator<UserCreateDto> userCreateDtoValidator, IMapper mapper, IValidator<UserUpdateDto> userUpdateeDtoValidator)
    {
        UserRepo = userRepo;
        UserCreateDtoValidator = userCreateDtoValidator;
        Mapper = mapper;
        UserUpdateDtoValidator = userUpdateeDtoValidator;
    }
    public async Task<User> AddAsync(UserCreateDto obj)
    {
        var validatorRes = await UserCreateDtoValidator.ValidateAsync(obj);
        if (validatorRes.IsValid == false)
        {
            throw new ValidationException($"{string.Join(',', validatorRes.Errors)}");
        }
        var user = Mapper.Map<User>(obj);
        return await UserRepo.AddAsync(user);
    }

    public async Task DeleteAsync(long id)
    {
        if (id < 0)
        {
            throw new ValidationException($"Not found id : {id}");
        }
        await UserRepo.DeleteAsync(id);
    }

    public async Task<ICollection<UserDto>> GetallAsync()
    {
        var all = UserRepo.GetAll();
        var res = await all.ToListAsync();
        return res.Select(g => Mapper.Map<UserDto>(g)).ToList();
    }

    public async Task<UserDto> GetByIdAsync(long id)
    {
        var byId = await UserRepo.GetByIdAsync(id);
        if (byId == null)
        {
            throw new KeyNotFoundException($"Not found id : {id}");
        }
        return Mapper.Map<UserDto>(byId);
    }

    public async Task UpdateAsync(UserUpdateDto obj)
    {
        var validator = await UserUpdateDtoValidator.ValidateAsync(obj);
        if (validator.IsValid == false)
        {
            throw new ValidationException($"{string.Join(',', validator.Errors)}");
        }
        var update = await UserRepo.GetByIdAsync(obj.Id);
        if (update == null)
        {
            throw new Exception($"Not found Id : {obj.Id}");
        }
        Mapper.Map(obj, update);
        await UserRepo.UpdateAsync(update);
    }
}
