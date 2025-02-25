using AutoMapper;
using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Dal.Entities;
using CarRendalSystem.Repoistory.Services;
using FluentValidation;

namespace CarRendalSystem.Bll.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepo PaymentRepo;
    private readonly IMapper Mapper;
    private readonly IValidator<PaymentCreateDto> PaymentCreateDtoValidator;
    private readonly IValidator<PaymentUpdateDto> PaymentDtoValidator;
    public PaymentService(IPaymentRepo paymentRepo, IMapper mapper, IValidator<PaymentCreateDto> paymentCreateDtoValidator, IValidator<PaymentUpdateDto> paymentPaymentDtoValidator)
    {
        PaymentRepo = paymentRepo;
        Mapper = mapper;
        PaymentCreateDtoValidator = paymentCreateDtoValidator;
        PaymentDtoValidator = paymentPaymentDtoValidator;
    }

    public async Task<Payment> AddAsync(PaymentCreateDto obj)
    {
        var validator = await PaymentCreateDtoValidator.ValidateAsync(obj);
        if (validator.IsValid == false)
        {
            throw new ValidationException($"{string.Join(',', validator.Errors)}");
        }
        var c = Mapper.Map<Payment>(obj);
        return await PaymentRepo.AddAsync(c);

    }

    public async Task DeleteAsync(long id)
    {
        if (id < 0)
        {
            throw new Exception($"Not found Id : {id} ");
        }
        await PaymentRepo.DeleteAsync(id);

    }

    public async Task<ICollection<PaymentGetDto>> GetAllAsync()
    {
        var all = await PaymentRepo.GetAllAsync();
        return all.Select(cp => Mapper.Map<PaymentGetDto>(cp)).ToList();
    }

    public async Task<PaymentGetDto> GetByIdAsync(long id)
    {
        var byId = await PaymentRepo.GetByIdAsync(id);
        if (byId == null)
        {
            throw new Exception("Not found By Id");
        }
        return Mapper.Map<PaymentGetDto>(byId);

    }

    public async Task UpdateAsync(PaymentUpdateDto obj)
    {
        var validator = await PaymentDtoValidator.ValidateAsync(obj);
        if (validator.IsValid == false)
        {
            throw new ValidationException($"{string.Join(',', validator.Errors)}");
        }
        var byId = await PaymentRepo.GetByIdAsync(obj.Id);
        if (byId == null)
        {
            throw new Exception("Not found By Id");
        }
        var c = Mapper.Map(obj, byId);
        await PaymentRepo.UpdateAsync(c);
    }
}



