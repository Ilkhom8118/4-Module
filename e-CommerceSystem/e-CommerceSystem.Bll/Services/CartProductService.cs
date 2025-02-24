using AutoMapper;
using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using e_CommerceSystem_.Dal.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace e_CommerceSystem.Bll.Services;

public class CartProductService : ICartProductService
{
    private readonly IMapper Mapper;
    private readonly ICartProductRepo CartProductRepo;
    private readonly IValidator<CartProductCreateDto> CartProductCreateDtoValidator;
    private readonly IValidator<CartProductUpdateDto> CartProductUpdateDtoValidator;
    public CartProductService(IMapper mapper, IValidator<CartProductCreateDto> cartProductCreateDtoValidator, IValidator<CartProductUpdateDto> cartProductUpdateDtoValidator, ICartProductRepo cartProductRepo)
    {
        Mapper = mapper;
        CartProductRepo = cartProductRepo;
        CartProductCreateDtoValidator = cartProductCreateDtoValidator;
        CartProductUpdateDtoValidator = cartProductUpdateDtoValidator;
    }

    public async Task<CartProduct> AddAsync(CartProductCreateDto obj)
    {
        var validator = await CartProductCreateDtoValidator.ValidateAsync(obj);
        if (validator.IsValid == false)
        {
            throw new ValidationException($"{string.Join(',', validator.Errors)}");
        }
        var cp = Mapper.Map<CartProduct>(obj);
        return await CartProductRepo.AddAsync(cp);
    }

    public async Task DeleteAsync(long cartId, long productId)
    {
        if (cartId < 0 && productId < 0)
        {
            throw new Exception($"Not found Id : {cartId} && {productId} ");
        }
        await CartProductRepo.DeleteAsync(cartId, productId);
    }

    public async Task<ICollection<CartProductDto>> GetAllAsync()
    {
        var all = CartProductRepo.GetAll();
        var res = await all.ToListAsync();
        return res.Select(cp => Mapper.Map<CartProductDto>(cp)).ToList();
    }

    public async Task<CartProductDto> GetByIdAsync(long cartId, long productId)
    {
        var byId = await CartProductRepo.GetByIdAsync(cartId, productId);
        if (byId == null)
        {
            throw new Exception("Not found By Id");
        }
        return Mapper.Map<CartProductDto>(byId);
    }

    public async Task UpdateAsync(CartProductUpdateDto obj)
    {
        var validator = await CartProductUpdateDtoValidator.ValidateAsync(obj);
        if (validator.IsValid == false)
        {
            throw new ValidationException($"{string.Join(',', validator.Errors)}");
        }
        var byId = await CartProductRepo.GetByIdAsync(obj.CartId, obj.ProductId);
        if (byId == null)
        {
            throw new Exception("Not found By Id");
        }
        var cp = Mapper.Map(obj, byId);
        await CartProductRepo.UpdateAsync(cp);
    }
}
