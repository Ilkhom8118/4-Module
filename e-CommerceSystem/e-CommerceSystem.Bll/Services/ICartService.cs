using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.Services;

public interface ICartService
{
    public Task<Cart> Addasync(CartCreateDto obj);
    public Task DeleteAsync(long id);
    public Task<CartDto> GetByIdAsync(long id);
    public Task<ICollection<CartDto>> GetAllAsync();
}