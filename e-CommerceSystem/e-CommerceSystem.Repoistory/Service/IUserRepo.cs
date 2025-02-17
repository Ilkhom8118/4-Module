using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Repoistory.Service;

public interface IUserRepo
{
    Task<User> AddAsync(User user);
    Task DeleteAsync(long id);
    Task UpdateAsync(User user);
    IQueryable<User> GetAll();
    Task<User> GetByIdAsync(long id);
}