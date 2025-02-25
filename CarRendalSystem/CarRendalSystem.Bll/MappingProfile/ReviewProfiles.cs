using AutoMapper;
using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Bll.MappingProfile;

public class ReviewProfiles : Profile
{
    public ReviewProfiles()
    {
        CreateMap<Review, ReviewGetDto>().ReverseMap();
        CreateMap<Review, ReviewCreateDto>().ReverseMap();
        CreateMap<Review, ReviewUpdateDto>().ReverseMap();
    }
}
