using CarRendalSystem.Dal.Entities;
using CarRendalSystem.Dal;
using Microsoft.EntityFrameworkCore;

namespace CarRendalSystem.Repoistory.Services;

public class PaymentRepo : IPaymentRepo
{
    private MainContext MainContext;

    public PaymentRepo(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<Payment> AddAsync(Payment obj)
    {
        await MainContext.Payments.AddAsync(obj);
        await MainContext.SaveChangesAsync();
        return obj;
    }

    public async Task DeleteAsync(long id)
    {
        var byId = await GetByIdAsync(id);
        MainContext.Remove(byId);
        await MainContext.SaveChangesAsync();
    }

    public async Task<List<Payment>> GetAllAsync()
    {
        return await MainContext.Payments.ToListAsync();
    }

    public async Task<Payment> GetByIdAsync(long id)
    {
        var obj = await MainContext.Payments.FirstOrDefaultAsync(b => b.Id == id);
        if (obj == null)
        {
            throw new Exception($"Not found Id : {id}");
        }
        return obj;
    }

    public async Task UpdateAsync(Payment obj)
    {
        var byId = GetByIdAsync(obj.Id);
        MainContext.Update(obj);
        await MainContext.SaveChangesAsync();
    }
}
