using e_CommerceSystem_.Dal;
using e_CommerceSystem_.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_CommerceSystem.Repoistory.Service;

public class CartRepo : ICartRepo
{
    private MainContext MainContext;

    public CartRepo(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<Cart> AddAsync(Cart obj)
    {
        await MainContext.AddAsync(obj);
        await MainContext.SaveChangesAsync();
        return obj;
    }

    public async Task DeleteAsync(long id)
    {
        var byId = GetByIdAsync(id);
        MainContext.Remove(byId);
        await MainContext.SaveChangesAsync();
    }

    public IQueryable<Cart> GetAll()
    {
        var list = MainContext.Carts;
        return list;
    }

    public async Task<Cart> GetByIdAsync(long id)
    {
        var byId = await MainContext.Carts.FirstOrDefaultAsync(c => c.Id == id);
        if (byId == null)
        {
            throw new Exception($"Cart not found : {id}");
        }
        return byId;
    }

    public async Task UpdateAsync(Cart obj)
    {
        var byId = await GetByIdAsync(obj.Id);
        MainContext.Update(byId);
        await MainContext.SaveChangesAsync();
    }
}
