using e_CommerceSystem_.Dal;
using e_CommerceSystem_.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_CommerceSystem.Repoistory.Service;

public class PaymentRepo : IPaymentRepo
{
    private MainContext MainContext;

    public PaymentRepo(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<Payment> AddAsync(Payment obj)
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

    public IQueryable<Payment> GetAll()
    {
        var all = MainContext.Payments;
        return all;
    }

    public async Task<Payment> GetByIdAsync(long id)
    {
        var byId = await MainContext.Payments.FirstOrDefaultAsync(p => p.Id == id);
        if (byId == null)
        {
            throw new Exception($"Payment not found {id}");
        }
        return byId;
    }

    public async Task UpdateAsync(Payment obj)
    {
        var update = GetByIdAsync(obj.Id);
        MainContext.Update(update);
        await MainContext.SaveChangesAsync();
    }
}
