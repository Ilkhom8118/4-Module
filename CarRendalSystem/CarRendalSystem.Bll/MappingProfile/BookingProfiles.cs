using AutoMapper;
using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Bll.MappingProfile;

public class BookingProfiles : Profile
{
    public BookingProfiles()
    {
        CreateMap<Booking, BookingGetDto>().ReverseMap();
        CreateMap<Booking, BookingCreateDto>().ReverseMap();
        CreateMap<Booking, BookingUpdateDto>().ReverseMap();
    }
}
