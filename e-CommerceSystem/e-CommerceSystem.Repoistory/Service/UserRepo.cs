using e_CommerceSystem_.Dal;
using e_CommerceSystem_.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_CommerceSystem.Repoistory.Service;

public class UserRepo : IUserRepo
{
    private MainContext MainContext;

    public UserRepo(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<User> AddAsync(User user)
    {
        await MainContext.AddAsync(user);
        await MainContext.SaveChangesAsync();
        return user;
    }

    public async Task DeleteAsync(long id)
    {
        var guid = await GetByIdAsync(id);
        MainContext.Users.Remove(guid);
        await MainContext.SaveChangesAsync();
    }

    public IQueryable<User> GetAll()
    {
        var user = MainContext.Users;
        return user;
    }

    public async Task<User> GetByIdAsync(long id)
    {
        var res = await MainContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (res == null)
        {
            throw new Exception($"User not found {id}");
        }
        return res;
    }

    public async Task UpdateAsync(User user)
    {
        var guid = await GetByIdAsync(user.Id);
        MainContext.Update(guid);
        await MainContext.SaveChangesAsync();
    }
}
