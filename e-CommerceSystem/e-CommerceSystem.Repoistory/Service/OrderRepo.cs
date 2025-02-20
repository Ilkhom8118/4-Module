using e_CommerceSystem_.Dal;
using e_CommerceSystem_.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_CommerceSystem.Repoistory.Service;

public class OrderRepo : IOrderRepo
{
    private MainContext MainContext;

    public OrderRepo(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<Order> AddAsync(Order obj)
    {
        await MainContext.AddAsync(obj);
        await MainContext.SaveChangesAsync();
        return obj;
    }

    public async Task DeleteAsync(long id)
    {
        var remove = await GetByIdAsync(id);
        MainContext.Remove(remove);
        await MainContext.SaveChangesAsync();
    }

    public IQueryable<Order> GetAll()
    {
        var all = MainContext.Orders;
        return all;
    }

    public async Task<Order> GetByIdAsync(long id)
    {
        var byId = await MainContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
        if (byId == null)
        {
            throw new Exception($"Order not found : {id}");
        }
        return byId;
    }

    public async Task UpdateAsync(Order obj)
    {
        var update = await GetByIdAsync(obj.Id);
        MainContext.Update(update);
        await MainContext.SaveChangesAsync();
    }
}
