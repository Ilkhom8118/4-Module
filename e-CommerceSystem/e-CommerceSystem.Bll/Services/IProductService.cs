using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.Services;

public interface IProductService
{
    Task<Product> AddAsync(ProductCreateDto obj);
    Task DeleteAsync(long id);
    Task UpdateAsync(ProductUpdateDto obj);
    Task<ProductDto> GetByIdAsync(long id);
    Task<ICollection<ProductDto>> GetallAsync();
}