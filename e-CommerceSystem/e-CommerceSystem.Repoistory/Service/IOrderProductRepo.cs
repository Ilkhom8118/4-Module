using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Repoistory.Service;

public interface IOrderProductRepo
{
    IQueryable<OrderProduct> GetAll();
    Task<OrderProduct> AddAsync(OrderProduct obj);
    Task DeleteAsync(long orderId, long productId);
    Task UpdateAsync(OrderProduct order, OrderProduct product);
    Task<OrderProduct> GetByIdAsync(long orderId, long productId);
}