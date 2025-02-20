using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Repoistory.Service;

public interface ICartProductRepo
{
    IQueryable<CartProduct> GetAll();
    Task<CartProduct> AddAsync(CartProduct obj);
    Task DeleteAsync(long cartId, long productId);
    Task UpdateAsync(CartProduct cart, CartProduct product);
    Task<CartProduct> GetByIdAsync(long cartId, long productId);
}