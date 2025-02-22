using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.Services;

public interface IUserService
{
    Task<User> AddAsync(UserCreateDto obj);
    Task DeleteAsync(long id);
    Task UpdateAsync(UserUpdateDto obj);
    Task<UserDto> GetByIdAsync(long id);
    Task<ICollection<UserDto>> GetallAsync();
}