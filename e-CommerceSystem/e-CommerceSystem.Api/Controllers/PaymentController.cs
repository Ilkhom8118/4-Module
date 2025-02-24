using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Bll.Services;
using e_CommerceSystem_.Dal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace e_CommerceSystem.Api.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentService Payment;

        public PaymentController(IPaymentService payment)
        {
            Payment = payment;
        }
        [HttpPost("add")]
        public async Task<Payment> AddAsync(PaymentCreateDto obj)
        {
            return await Payment.AddAsync(obj);
        }
        [HttpDelete("delete")]
        public async Task DeleteAsync(long id)
        {
            await Payment.DeleteAsync(id);
        }
        [HttpPut("update")]
        public async Task UpdateAsync(PaymentUpdateDto obj)
        {
            await Payment.UpdateAsync(obj);
        }
        [HttpGet("getAll")]
        public async Task<ICollection<PaymentDto>> GetAllAsync()
        {
            return await Payment.GetAllAsync();
        }
        [HttpGet("getById")]
        public async Task<PaymentDto> GetById(long id)
        {
            return await Payment.GetByIdAsync(id);
        }
    }
}
