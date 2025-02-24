using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.Services;

public interface IOrderService
{
    Task<Order> AddAsync(OrderCreateDto obj);
    Task DeleteAsync(long id);
    Task UpdateAsync(OrderUpdateDto obj);
    Task<OrderDto> GetByIdAsync(long id);
    Task<ICollection<OrderDto>> GetAllAsync();
}