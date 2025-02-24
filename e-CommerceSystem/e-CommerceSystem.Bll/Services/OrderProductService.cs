using AutoMapper;
using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using e_CommerceSystem_.Dal.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace e_CommerceSystem.Bll.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepo OrderProductRepo;
        private readonly IValidator<OrderProductCreateDto> OrderProductCreateDtoValidator;
        private readonly IValidator<OrderProductUpdateDto> OrderProductUpdateDtoValidator;
        private readonly IMapper Mapper;
        public OrderProductService(IOrderProductRepo orderProductRepo, IValidator<OrderProductCreateDto> orderProductCreateDtoValidator, IValidator<OrderProductUpdateDto> orderProductUpdateDtoValidator, IMapper mapper)
        {
            OrderProductRepo = orderProductRepo;
            OrderProductCreateDtoValidator = orderProductCreateDtoValidator;
            OrderProductUpdateDtoValidator = orderProductUpdateDtoValidator;
            Mapper = mapper;
        }

        public async Task<OrderProduct> AddAsync(OrderProductCreateDto obj)
        {
            var validator = await OrderProductCreateDtoValidator.ValidateAsync(obj);
            if (validator.IsValid == false)
            {
                throw new ValidationException($"{string.Join(',', validator.Errors)}");
            }
            var res = Mapper.Map<OrderProduct>(obj);
            return await OrderProductRepo.AddAsync(res);
        }

        public async Task DeleteAsync(long orderId, long productId)
        {
            if (orderId < 0 && productId < 0)
            {
                throw new Exception("Not found Id");
            }
            await OrderProductRepo.DeleteAsync(orderId, productId);
        }

        public async Task<ICollection<OrderProductDto>> GetAllAsync()
        {
            var all = OrderProductRepo.GetAll();
            var res = await all.ToListAsync();
            return res.Select(op => Mapper.Map<OrderProductDto>(op)).ToList();
        }

        public async Task<OrderProductDto> GetByIdAsync(long orderId, long productId)
        {
            var byId = await OrderProductRepo.GetByIdAsync(orderId, productId);
            if (byId == null)
            {
                throw new Exception("Not found By Id");
            }
            return Mapper.Map<OrderProductDto>(byId);
        }

        public async Task UpdateAsync(OrderProductUpdateDto obj)
        {
            var validator = await OrderProductUpdateDtoValidator.ValidateAsync(obj);
            if (validator.IsValid == false)
            {
                throw new ValidationException($"{string.Join(',', validator.Errors)}");
            }
            var byId = await OrderProductRepo.GetByIdAsync(obj.OrderId, obj.ProductId);
            if (byId == null)
            {
                throw new Exception("Not found By Id");
            }
            var op = Mapper.Map(obj, byId);
            await OrderProductRepo.UpdateAsync(op);
        }
    }
}
