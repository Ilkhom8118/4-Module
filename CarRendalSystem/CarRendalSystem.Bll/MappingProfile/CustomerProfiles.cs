using AutoMapper;
using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Bll.MappingProfile;

public class CustomerProfiles : Profile
{
    public CustomerProfiles()
    {
        CreateMap<Customer, CustomerGetDto>().ReverseMap();
        CreateMap<Customer, CustomerCreateDto>().ReverseMap();
        CreateMap<Customer, CustomerUpdateDto>().ReverseMap();
    }
}
