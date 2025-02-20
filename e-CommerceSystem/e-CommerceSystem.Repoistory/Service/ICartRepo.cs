using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Repoistory.Service;

public interface ICartRepo
{
    Task<Cart> AddAsync(Cart obj);
    Task DeleteAsync(long id);
    Task UpdateAsync(Cart obj);
    Task<Cart> GetByIdAsync(long id);
    IQueryable<Cart> GetAll();
}