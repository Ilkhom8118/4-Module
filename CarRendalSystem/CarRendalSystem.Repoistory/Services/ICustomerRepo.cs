using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Repoistory.Services
{
    public interface ICustomerRepo
    {
        Task<Customer> AddAsync(Customer obj);
        Task DeleteAsync(long id);
        Task UpdateAsync(Customer obj);
        Task<Customer> GetByIdAsync(long id);
        Task<List<Customer>> GetAllAsync();
    }
}