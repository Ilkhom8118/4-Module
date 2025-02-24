using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.Services;

public interface IOrderProductService
{
    Task<OrderProduct> AddAsync(OrderProductCreateDto obj);
    Task DeleteAsync(long orderId, long productId);
    Task UpdateAsync(OrderProductUpdateDto obj);
    Task<OrderProductDto> GetByIdAsync(long orderId, long productId);
    Task<ICollection<OrderProductDto>> GetAllAsync();
}