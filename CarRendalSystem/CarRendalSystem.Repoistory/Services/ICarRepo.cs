using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Repoistory.Services
{
    public interface ICarRepo
    {
        Task<Car> AddAsync(Car obj);
        Task DeleteAsync(long id);
        Task UpdateAsync(Car obj);
        Task<Car> GetByIdAsync(long id);
        Task<List<Car>> GetAllAsync();
    }
}