using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Bll.Services;
using e_CommerceSystem_.Dal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace e_CommerceSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService UserService;
    public UserController(IUserService userService)
    {
        UserService = userService;
    }
    [HttpPost("add")]
    public async Task<User> AddPost(UserCreateDto userCreateDto)
    {
        return await UserService.AddAsync(userCreateDto);
    }
    [HttpDelete("deleteUser")]
    public async Task DeleteUser(long id)
    {
        await UserService.DeleteAsync(id);
    }
    [HttpPut("updateUser")]
    public async Task UpdateAsync(UserDto obj)
    {
        await UserService.UpdateAsync(obj);
    }
    [HttpGet("getAllUser")]
    public async Task<ICollection<UserDto>> GetAll()
    {
        return await UserService.GetallAsync();
    }
    [HttpGet("getByIdUser")]
    public async Task<UserDto> GetByIdAsync(long id)
    {
        return await UserService.GetByIdAsync(id);
    }
}
