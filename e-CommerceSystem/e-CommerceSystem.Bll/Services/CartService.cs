using AutoMapper;
using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using e_CommerceSystem_.Dal.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace e_CommerceSystem.Bll.Services;

public class CartService : ICartService
{
    private readonly ICartRepo CartRepo;
    private readonly IMapper Mapper;
    private readonly IValidator<CartCreateDto> CartDtoValidator;
    public CartService(ICartRepo cartRepo, IMapper mapper, IValidator<CartCreateDto> cartDtoValidator)
    {
        CartRepo = cartRepo;
        Mapper = mapper;
        CartDtoValidator = cartDtoValidator;
    }

    public async Task<Cart> Addasync(CartCreateDto obj)
    {
        var validator = await CartDtoValidator.ValidateAsync(obj);
        if (validator.IsValid == false)
        {
            throw new ValidationException($"{string.Join(',', validator.Errors)}");
        }
        var cart = Mapper.Map<Cart>(obj);
        return await CartRepo.AddAsync(cart);
    }

    public async Task DeleteAsync(long id)
    {
        if (id < 0)
        {
            throw new Exception($"Not found Id : {id}");
        }
        await CartRepo.DeleteAsync(id);
    }

    public async Task<ICollection<CartDto>> GetAllAsync()
    {
        var all = CartRepo.GetAll();
        var res = await all.ToListAsync();
        return res.Select(c => Mapper.Map<CartDto>(c)).ToList();
    }

    public async Task<CartDto> GetByIdAsync(long id)
    {
        var byId = await CartRepo.GetByIdAsync(id);
        if (byId == null)
        {
            throw new Exception($"Not found Id : {id}");
        }
        return Mapper.Map<CartDto>(byId);
    }
}
