using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Repoistory.Service;

public interface ICartProductRepo
{
    Task<CartProduct> AddAsync(CartProduct obj);
    Task DeleteAsync(long id);
    Task UpdateAsync(CartProduct obj);
    Task<CartProduct> GetByIdAsync(long id);
    IQueryable<CartProduct> GetAll();
}