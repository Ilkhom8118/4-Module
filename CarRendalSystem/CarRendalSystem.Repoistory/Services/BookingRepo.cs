using CarRendalSystem.Dal;
using CarRendalSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRendalSystem.Repoistory.Services;

public class BookingRepo : IBookingRepo
{
    private MainContext MainContext;

    public BookingRepo(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<Booking> AddAsync(Booking obj)
    {
        await MainContext.Bookings.AddAsync(obj);
        await MainContext.SaveChangesAsync();
        return obj;
    }

    public async Task DeleteAsync(long id)
    {
        var byId = await GetByIdAsync(id);
        MainContext.Remove(byId);
        await MainContext.SaveChangesAsync();
    }

    public async Task<List<Booking>> GetAllAsync()
    {
        return await MainContext.Bookings.ToListAsync();
    }

    public async Task<Booking> GetByIdAsync(long id)
    {
        var obj = await MainContext.Bookings.FirstOrDefaultAsync(b => b.Id == id);
        if (obj == null)
        {
            throw new Exception($"Not found Id : {id}");
        }
        return obj;
    }

    public async Task UpdateAsync(Booking obj)
    {
        var byId = GetByIdAsync(obj.Id);
        MainContext.Update(obj);
        await MainContext.SaveChangesAsync();
    }
}
