using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.Services;

public interface IPaymentService
{
    Task<Payment> AddAsync(PaymentCreateDto obj);
    Task DeleteAsync(long id);
    Task UpdateAsync(PaymentUpdateDto obj);
    Task<PaymentDto> GetByIdAsync(long id);
    Task<ICollection<PaymentDto>> GetAllAsync();
}