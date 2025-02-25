using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Bll.Services;
using CarRendalSystem.Dal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRendalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService CustomerService;

        public CustomerController(ICustomerService customerService)
        {
            CustomerService = customerService;
        }
        

        [HttpPost("add")]
        public async Task<Customer> AddAsync(CustomerCreateDto obj)
        {
            return await CustomerService.AddAsync(obj);
        }
        [HttpDelete("delete")]
        public async Task DeleteAsync(long id)
        {
            await CustomerService.DeleteAsync(id);
        }
        [HttpPut("update")]
        public async Task UpdateAsync(CustomerUpdateDto obj)
        {
            await CustomerService.UpdateAsync(obj);
        }
        [HttpGet("getById")]
        public async Task<CustomerGetDto> GetByIdAsync(long id)
        {
            return await CustomerService.GetByIdAsync(id);
        }
        [HttpGet("getAll")]
        public async Task<ICollection<CustomerGetDto>> GetAllAsync()
        {
            return await CustomerService.GetAllAsync();
        }
    }
}
