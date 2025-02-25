using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Bll.Services
{
    public interface ICustomerService
    {
        Task<Customer> AddAsync(CustomerCreateDto obj);
        Task DeleteAsync(long id);
        Task UpdateAsync(CustomerUpdateDto obj);
        Task<CustomerGetDto> GetByIdAsync(long id);
        Task<ICollection<CustomerGetDto>> GetAllAsync();
    }
}