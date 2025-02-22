using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Repoistory.Services;

public interface IBookingRepo
{
    Task<Booking> AddAsync(Booking obj);
    Task DeleteAsync(long id);
    Task UpdateAsync(Booking obj);
    Task<Booking> GetByIdAsync(long id);
    Task<List<Booking>> GetAllAsync();
}