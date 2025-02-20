using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Repoistory.Service;

public interface IPaymentRepo
{
    Task DeleteAsync(long id);
    IQueryable<Payment> GetAll();
    Task UpdateAsync(Payment obj);
    Task<Payment> GetByIdAsync(long id);
    Task<Payment> AddAsync(Payment obj);
}