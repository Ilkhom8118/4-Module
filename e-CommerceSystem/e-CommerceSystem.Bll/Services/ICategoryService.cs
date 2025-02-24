using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.Services
{
    public interface ICategoryService
    {
        Task<Category> AddAsync(CategoryCreateDto obj);
        Task DeleteAsync(long id);
        Task UpdateAsync(CategoryUpdateDto obj);
        Task<CategoryDto> GetByIdAsync(long id);
        Task<ICollection<CategoryDto>> GetAllAsync();
    }
}