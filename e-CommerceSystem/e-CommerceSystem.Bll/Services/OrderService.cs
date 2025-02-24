using AutoMapper;
using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using e_CommerceSystem_.Dal.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace e_CommerceSystem.Bll.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepo OrderRepo;
    private readonly IMapper Mapper;
    private readonly IValidator<OrderCreateDto> OrderCreateDtoValidator;
    private readonly IValidator<OrderUpdateDto> OrderUpdateDtoValidator;
    public OrderService(IOrderRepo orderRepo, IMapper mapper, IValidator<OrderCreateDto> orderCreateDtoValidator, IValidator<OrderUpdateDto> orderUpdateDtoValidator)
    {
        OrderRepo = orderRepo;
        Mapper = mapper;
        OrderCreateDtoValidator = orderCreateDtoValidator;
        OrderUpdateDtoValidator = orderUpdateDtoValidator;
    }

    public async Task<Order> AddAsync(OrderCreateDto obj)
    {
        var validator = await OrderCreateDtoValidator.ValidateAsync(obj);
        if (validator.IsValid == false)
        {
            throw new ValidationException($"{string.Join(',', validator.Errors)}");
        }
        var order = Mapper.Map<Order>(obj);
        return await OrderRepo.AddAsync(order);
    }

    public async Task DeleteAsync(long id)
    {
        if (id < 0)
        {
            throw new Exception($"Not found Id {id}");
        }
        await OrderRepo.DeleteAsync(id);
    }

    public async Task<ICollection<OrderDto>> GetAllAsync()
    {
        var all = OrderRepo.GetAll();
        var res = await all.ToListAsync();
        return res.Select(o => Mapper.Map<OrderDto>(o)).ToList();
    }

    public async Task<OrderDto> GetByIdAsync(long id)
    {
        var byId = await OrderRepo.GetByIdAsync(id);
        if (byId == null)
        {
            throw new Exception($"Not found By Id {id}");
        }
        return Mapper.Map<OrderDto>(byId);
    }

    public async Task UpdateAsync(OrderUpdateDto obj)
    {
        var validator = await OrderUpdateDtoValidator.ValidateAsync(obj);
        if (validator.IsValid == false)
        {
            throw new ValidationException($"{string.Join(',', validator.Errors)}");
        }
        var byId = await OrderRepo.GetByIdAsync(obj.Id);
        if (byId == null)
        {
            throw new Exception($"Not found by Id : {obj.Id}");
        }
        var order = Mapper.Map(obj, byId);
        await OrderRepo.UpdateAsync(order);
    }
}
