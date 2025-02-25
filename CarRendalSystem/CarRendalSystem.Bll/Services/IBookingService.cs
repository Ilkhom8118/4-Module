using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Bll.Services
{
    public interface IBookingService
    {
        Task<Booking> AddAsync(BookingCreateDto obj);
        Task DeleteAsync(long id);
        Task UpdateAsync(BookingUpdateDto obj);
        Task<BookingGetDto> GetByIdAsync(long id);
        Task<ICollection<BookingGetDto>> GetAllAsync();
    }
}