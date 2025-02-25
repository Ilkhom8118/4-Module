using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Bll.Services;
using CarRendalSystem.Dal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRendalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService PaymentService;

        public PaymentController(IPaymentService paymentService)
        {
            PaymentService = paymentService;
        }
        [HttpPost("add")]
        public async Task<Payment> AddAsync(PaymentCreateDto obj)
        {
            return await PaymentService.AddAsync(obj);
        }
        [HttpDelete("delete")]
        public async Task DeleteAsync(long id)
        {
            await PaymentService.DeleteAsync(id);
        }
        [HttpPut("update")]
        public async Task UpdateAsync(PaymentUpdateDto obj)
        {
            await PaymentService.UpdateAsync(obj);
        }
        [HttpGet("getById")]
        public async Task<PaymentGetDto> GetByIdAsync(long id)
        {
            return await PaymentService.GetByIdAsync(id);
        }
        [HttpGet("getAll")]
        public async Task<ICollection<PaymentGetDto>> GetAllAsync()
        {
            return await PaymentService.GetAllAsync();
        }
    }
}
