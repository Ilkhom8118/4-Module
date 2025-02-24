using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Bll.Services;
using e_CommerceSystem_.Dal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace e_CommerceSystem.Api.Controllers
{
    [Route("api/orderProduct")]
    [ApiController]
    public class OrderProductController : ControllerBase
    {
        private readonly IOrderProductService Op;

        public OrderProductController(IOrderProductService orderProductService)
        {
            Op = orderProductService;
        }
        [HttpPost("add")]
        public async Task<OrderProduct> AddAsync(OrderProductCreateDto obj)
        {
            return await Op.AddAsync(obj);
        }
        [HttpDelete("delete")]
        public async Task DeleteAsync(long orderId, long productId)
        {
            await Op.DeleteAsync(orderId, productId);
        }
        [HttpPut("update")]
        public async Task UpdateAsync(OrderProductUpdateDto obj)
        {
            await Op.UpdateAsync(obj);
        }
        [HttpGet("byId")]
        public async Task<OrderProductDto> GetByIdAsync(long orderId, long productId)
        {
            return await Op.GetByIdAsync(orderId, productId);
        }
        [HttpGet("getAll")]
        public async Task<ICollection<OrderProductDto>> GetAllAsync()
        {
            return await Op.GetAllAsync();
        }
    }
}
