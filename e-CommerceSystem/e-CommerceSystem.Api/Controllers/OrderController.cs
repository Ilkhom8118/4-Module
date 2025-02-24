using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Bll.Services;
using e_CommerceSystem_.Dal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace e_CommerceSystem.Api.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService Order;

        public OrderController(IOrderService order)
        {
            Order = order;
        }
        [HttpPost("add")]
        public async Task<Order> AddAsync(OrderCreateDto obj)
        {
            return await Order.AddAsync(obj);
        }
        [HttpDelete("delete")]
        public async Task DeleteAsync(long id)
        {
            await Order.DeleteAsync(id);
        }
        [HttpPut("update")]
        public async Task UpdateAsync(OrderUpdateDto obj)
        {
            await Order.UpdateAsync(obj);
        }
        [HttpGet("getById")]
        public async Task<OrderDto> GetByIdAsync(long id)
        {
            return await Order.GetByIdAsync(id);
        }
        [HttpGet("getAll")]
        public async Task<ICollection<OrderDto>> GetAllAsync()
        {
            return await Order.GetAllAsync();
        }
    }
}
