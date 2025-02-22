using CarRendalSystem.Dal;
using CarRendalSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRendalSystem.Repoistory.Services;

public class CustomerRepo : ICustomerRepo
{
    private MainContext MainContext;

    public CustomerRepo(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<Customer> AddAsync(Customer obj)
    {
        await MainContext.Customers.AddAsync(obj);
        await MainContext.SaveChangesAsync();
        return obj;
    }

    public async Task DeleteAsync(long id)
    {
        var byId = await GetByIdAsync(id);
        MainContext.Remove(byId);
        await MainContext.SaveChangesAsync();
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await MainContext.Customers.ToListAsync();
    }

    public async Task<Customer> GetByIdAsync(long id)
    {
        var obj = await MainContext.Customers.FirstOrDefaultAsync(b => b.Id == id);
        if (obj == null)
        {
            throw new Exception($"Not found Id : {id}");
        }
        return obj;
    }

    public async Task UpdateAsync(Customer obj)
    {
        var byId = GetByIdAsync(obj.Id);
        MainContext.Update(obj);
        await MainContext.SaveChangesAsync();
    }
}
