using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Repoistory.Service;

public interface IProductRepo
{
    Task<Product> AddAsync(Product obj);
    Task DeleteAsync(long id);
    Task UpdateAsync(Product obj);
    IQueryable<Product> GetAll();
    Task<Product> GetByIdAsync(long id);
}