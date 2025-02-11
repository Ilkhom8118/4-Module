using Instagram.Bll.DTOs;
using Instagram.Bll.Services;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService CommentService;

        public CommentController(ICommentService commentService)
        {
            CommentService = commentService;
        }
        [HttpPost("add")]
        public async Task<CommentGetDto> AddComment(CommentCreateDto obj)
        {
            return await CommentService.AddAsync(obj);
        }
        [HttpGet("getAll")]
        public async Task<List<CommentGetDto>> GetAllComment()
        {
            return await CommentService.GetAllAsync();
        }
    }
}
