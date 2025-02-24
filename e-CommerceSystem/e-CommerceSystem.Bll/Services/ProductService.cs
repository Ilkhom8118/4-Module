using AutoMapper;
using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using e_CommerceSystem_.Dal.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace e_CommerceSystem.Bll.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo ProductRepo;
        private readonly IMapper Mapper;
        private readonly IValidator<ProductCreateDto> ProductCreateValidator;
        private readonly IValidator<ProductUpdateDto> ProductUpdateValidator;
        public ProductService(IProductRepo productRepo, IMapper mapper, IValidator<ProductCreateDto> productCreateValidator, IValidator<ProductUpdateDto> productUpdateValidator)
        {
            Mapper = mapper;
            ProductRepo = productRepo;
            ProductCreateValidator = productCreateValidator;
            ProductUpdateValidator = productUpdateValidator;
        }

        public async Task<Product> AddAsync(ProductCreateDto obj)
        {
            var validator = await ProductCreateValidator.ValidateAsync(obj);
            if (validator.IsValid == false)
            {
                throw new ValidationException($"{string.Join(',', validator.Errors)}");
            }
            var product = Mapper.Map<Product>(obj);
            return await ProductRepo.AddAsync(product);
        }

        public async Task DeleteAsync(long id)
        {
            if (id < 0)
            {
                throw new ValidationException($"Not found Id : {id}");
            }
            await ProductRepo.DeleteAsync(id);
        }

        public async Task<ICollection<ProductDto>> GetallAsync()
        {
            var all = ProductRepo.GetAll();
            var res = await all.ToListAsync();
            return res.Select(p => Mapper.Map<ProductDto>(p)).ToList();
        }

        public async Task<ProductDto> GetByIdAsync(long id)
        {
            var byId = await ProductRepo.GetByIdAsync(id);
            if (byId == null)
            {
                throw new ValidationException($"Not found Id : {id}");
            }
            return Mapper.Map<ProductDto>(byId);
        }

        public async Task UpdateAsync(ProductUpdateDto obj)
        {
            var validator = await ProductUpdateValidator.ValidateAsync(obj);
            if (validator.IsValid == false)
            {
                throw new ValidationException($"{string.Join(',', validator.Errors)}");
            }
            var idObj = await ProductRepo.GetByIdAsync(obj.Id);
            if (idObj == null)
            {
                throw new ValidationException($"Not found Id : {obj.Id}");
            }
            var p = Mapper.Map(obj, idObj);
            await ProductRepo.UpdateAsync(p);

        }
    }
}
