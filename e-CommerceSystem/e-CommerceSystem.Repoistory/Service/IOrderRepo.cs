using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Repoistory.Service;

public interface IOrderRepo
{
    Task<Order> AddAsync(Order obj);
    Task DeleteAsync(long id);
    Task UpdateAsync(Order obj);
    IQueryable<Order> GetAll();
    Task<Order> GetByIdAsync(long id);
}