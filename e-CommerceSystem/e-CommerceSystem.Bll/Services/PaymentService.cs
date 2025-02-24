using AutoMapper;
using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using e_CommerceSystem_.Dal.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace e_CommerceSystem.Bll.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepo PaymentRepo;
        private readonly IMapper Mapper;
        private readonly IValidator<PaymentCreateDto> PaymentCreateDtoValidator;
        private readonly IValidator<PaymentUpdateDto> PaymentUpdateDtoValidator;
        public PaymentService(IPaymentRepo paymentRepo, IMapper mapper, IValidator<PaymentCreateDto> paymentCreateDtoValidator, IValidator<PaymentUpdateDto> paymentUpdateDtoValidator)
        {
            PaymentRepo = paymentRepo;
            Mapper = mapper;
            PaymentCreateDtoValidator = paymentCreateDtoValidator;
            PaymentUpdateDtoValidator = paymentUpdateDtoValidator;
        }

        public async Task<Payment> AddAsync(PaymentCreateDto obj)
        {
            var validator = await PaymentCreateDtoValidator.ValidateAsync(obj);
            if (validator.IsValid == false)
            {
                throw new ValidationException($"{string.Join(',', validator.Errors)}");
            }
            var payment = Mapper.Map<Payment>(obj);
            return await PaymentRepo.AddAsync(payment);
        }

        public async Task DeleteAsync(long id)
        {
            if (id < 0)
            {
                throw new Exception("Not found Id");
            }
            await PaymentRepo.DeleteAsync(id);
        }

        public async Task<ICollection<PaymentDto>> GetAllAsync()
        {
            var all = PaymentRepo.GetAll();
            var res = await all.ToListAsync();
            return res.Select(p => Mapper.Map<PaymentDto>(p)).ToList();
        }

        public async Task<PaymentDto> GetByIdAsync(long id)
        {
            var byId = await PaymentRepo.GetByIdAsync(id);
            if (byId == null)
            {
                throw new Exception("Not found By Id");
            }
            return Mapper.Map<PaymentDto>(byId);
        }

        public async Task UpdateAsync(PaymentUpdateDto obj)
        {
            var validator = await PaymentUpdateDtoValidator.ValidateAsync(obj);
            if (validator.IsValid == false)
            {
                throw new ValidationException($"{string.Join(',', validator.Errors)}");
            }
            var byId = await PaymentRepo.GetByIdAsync(obj.Id);
            if (byId == null)
            {
                throw new Exception("Not found By Id");
            }
            var payment = Mapper.Map(obj, byId);
            await PaymentRepo.UpdateAsync(payment);
        }
    }
}
