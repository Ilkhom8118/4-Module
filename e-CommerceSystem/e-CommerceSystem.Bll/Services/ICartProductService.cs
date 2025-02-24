using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.Services;

public interface ICartProductService
{
    public Task<CartProduct> AddAsync(CartProductCreateDto obj);
    public Task DeleteAsync(long cartId, long productId);
    public Task UpdateAsync(CartProductUpdateDto obj);
    public Task<CartProductDto> GetByIdAsync(long cartId, long productId);
    public Task<ICollection<CartProductDto>> GetAllAsync();
}