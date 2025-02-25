using AutoMapper;
using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Bll.Validators;
using CarRendalSystem.Dal.Entities;
using CarRendalSystem.Repoistory.Services;
using FluentValidation;

namespace CarRendalSystem.Bll.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepo CustomerRepo;
    private readonly IMapper Mapper;
    private readonly IValidator<CustomerCreateDto> CustomerCreateDtoValidator;
    private readonly IValidator<CustomerUpdateDto> CustomerUpdateDtoValidator;
    public CustomerService(ICustomerRepo customerRepo, IMapper mapper, IValidator<CustomerCreateDto> customerCreateDtoValidator, IValidator<CustomerUpdateDto> customerUpdateDtoValidator)
    {
        CustomerRepo = customerRepo;
        Mapper = mapper;
        CustomerCreateDtoValidator = customerCreateDtoValidator;
        CustomerUpdateDtoValidator = customerUpdateDtoValidator;
    }

    public async Task<Customer> AddAsync(CustomerCreateDto obj)
    {
        var validator = await CustomerCreateDtoValidator.ValidateAsync(obj);
        if (validator.IsValid == false)
        {
            throw new ValidationException($"{string.Join(',', validator.Errors)}");
        }
        var c = Mapper.Map<Customer>(obj);
        return await CustomerRepo.AddAsync(c);
    }

    public async Task DeleteAsync(long id)
    {
        if (id < 0)
        {
            throw new Exception($"Not found Id : {id} ");
        }
        await CustomerRepo.DeleteAsync(id);

    }

    public async Task<ICollection<CustomerGetDto>> GetAllAsync()
    {
        var all = await CustomerRepo.GetAllAsync();
        return all.Select(cp => Mapper.Map<CustomerGetDto>(cp)).ToList();
        
    }

    public async Task<CustomerGetDto> GetByIdAsync(long id)
    {
        var byId = await CustomerRepo.GetByIdAsync(id);
        if (byId == null)
        {
            throw new Exception("Not found By Id");
        }
        return Mapper.Map<CustomerGetDto>(byId);
        
    }

    public async Task UpdateAsync(CustomerUpdateDto obj)
    {
        var validator = await CustomerUpdateDtoValidator.ValidateAsync(obj);
        if (validator.IsValid == false)
        {
            throw new ValidationException($"{string.Join(',', validator.Errors)}");
        }
        var byId = await CustomerRepo.GetByIdAsync(obj.Id);
        if (byId == null)
        {
            throw new Exception("Not found By Id");
        }
        var c = Mapper.Map(obj, byId);
        await CustomerRepo.UpdateAsync(c);
    }
}