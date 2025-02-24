using AutoMapper;
using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Repoistory.Service;
using e_CommerceSystem_.Dal.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


namespace e_CommerceSystem.Bll.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepo CategoryRepo;
        private IMapper Mapper;
        private readonly IValidator<CategoryCreateDto> CategoryCreateDtoValidator;
        private readonly IValidator<CategoryUpdateDto> CategoryUpdateDtoValidator;
        public CategoryService(ICategoryRepo categoryRepo, IMapper mapper, IValidator<CategoryCreateDto> categoryCreateDtoValidator, IValidator<CategoryUpdateDto> categoryUpdateDtoValidator)
        {
            CategoryRepo = categoryRepo;
            Mapper = mapper;
            CategoryCreateDtoValidator = categoryCreateDtoValidator;
            CategoryUpdateDtoValidator = categoryUpdateDtoValidator;
        }

        public async Task<Category> AddAsync(CategoryCreateDto obj)
        {
            var validator = await CategoryCreateDtoValidator.ValidateAsync(obj);
            if (validator.IsValid == false)
            {
                throw new ValidationException($"{string.Join(',', validator.Errors)}");
            }
            var category = Mapper.Map<Category>(obj);
            return await CategoryRepo.AddAsync(category);
        }

        public async Task DeleteAsync(long id)
        {
            if (id < 0)
            {
                throw new ValidationException($"Not found Id : {id}");
            }
            await CategoryRepo.DeleteAsync(id);
        }

        public async Task<ICollection<CategoryDto>> GetAllAsync()
        {
            var all = CategoryRepo.GetAll();
            var res = await all.ToListAsync();
            return res.Select(c => Mapper.Map<CategoryDto>(c)).ToList();
        }

        public async Task<CategoryDto> GetByIdAsync(long id)
        {
            var byId = await CategoryRepo.GetbyIdAsync(id);
            if (byId == null)
            {
                throw new Exception($"Not found Id : {id}");
            }
            return Mapper.Map<CategoryDto>(byId);
        }

        public async Task UpdateAsync(CategoryUpdateDto obj)
        {
            var validator = await CategoryUpdateDtoValidator.ValidateAsync(obj);
            if (validator.IsValid == false)
            {
                throw new ValidationException($"{string.Join(',', validator.Errors)}");
            }
            var byId = await CategoryRepo.GetbyIdAsync(obj.Id);
            if (byId == null)
            {
                throw new Exception($"Not by Id : {obj.Id}");
            }
            var c = Mapper.Map(obj, byId);
            await CategoryRepo.UpdateAsync(c);
        }
    }
}
