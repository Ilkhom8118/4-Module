using AutoMapper;
using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Bll.MappingProfile
{
    public class CarProfiles : Profile
    {
        public CarProfiles()
        {
            CreateMap<Car, CarGetDto>().ReverseMap();
            CreateMap<Car, CarCreateDto>().ReverseMap();
            CreateMap<Car, CarUpdateDto>().ReverseMap();
        }
    }
}
