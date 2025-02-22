using AutoMapper;
using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.MappingProfiles;


public class UserProfiles : Profile
{
    public UserProfiles()
    {
        CreateMap<UserCreateDto, User>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();
    }
}
