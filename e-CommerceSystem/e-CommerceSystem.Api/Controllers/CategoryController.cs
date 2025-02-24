using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Bll.Services;
using e_CommerceSystem_.Dal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace e_CommerceSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService CategoryService;

        public CategoryController(ICategoryService categoryService)
        {
            CategoryService = categoryService;
        }
        [HttpPost("add")]
        public async Task<Category> AddAsync(CategoryCreateDto obj)
        {
            return await CategoryService.AddAsync(obj);
        }
        [HttpDelete("delete")]
        public async Task DeleteAsync(long id)
        {
            await CategoryService.DeleteAsync(id);
        }
        [HttpPut("update")]
        public async Task UpdateAsync(CategoryUpdateDto obj)
        {
            await CategoryService.UpdateAsync(obj);
        }
        [HttpGet("getById")]
        public async Task<CategoryDto> GetByIdAsync(long id)
        {
            return await CategoryService.GetByIdAsync(id);
        }
        [HttpGet("getAll")]
        public async Task<ICollection<CategoryDto>> GetAllAsync()
        {
            return await CategoryService.GetAllAsync();
        }
    }
}
