using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Repoistory.Service;

public interface ICategoryRepo
{
    Task<Category> AddAsync(Category obj);
    Task DeleteAsync(long id);
    Task UpdateAsync(Category obj);
    IQueryable<Category> GetAll();
    Task<Category> GetbyIdAsync(long id);
}