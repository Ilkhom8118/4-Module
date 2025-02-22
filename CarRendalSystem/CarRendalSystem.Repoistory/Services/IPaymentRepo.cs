using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Repoistory.Services
{
    public interface IPaymentRepo
    {
        Task<Payment> AddAsync(Payment obj);
        Task DeleteAsync(long id);
        Task UpdateAsync(Payment obj);
        Task<Payment> GetByIdAsync(long id);
        Task<List<Payment>> GetAllAsync();
    }
}