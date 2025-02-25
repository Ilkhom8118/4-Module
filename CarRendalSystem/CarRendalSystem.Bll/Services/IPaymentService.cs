using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Bll.Services
{
    public interface IPaymentService
    {
        Task<Payment> AddAsync(PaymentCreateDto obj);
        Task DeleteAsync(long id);
        Task UpdateAsync(PaymentUpdateDto obj);
        Task<PaymentGetDto> GetByIdAsync(long id);
        Task<ICollection<PaymentGetDto>> GetAllAsync();
    }
}