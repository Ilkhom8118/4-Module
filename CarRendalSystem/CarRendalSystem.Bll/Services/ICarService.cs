using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Bll.Services
{
    public interface ICarService
    {
        Task<Car> AddAsync(CarCreateDto obj);
        Task DeleteAsync(long id);
        Task UpdateAsync(CarUpdateDto obj);
        Task<CarGetDto> GetByIdAsync(long id);
        Task<ICollection<CarGetDto>> GetAllAsync();
    }
}