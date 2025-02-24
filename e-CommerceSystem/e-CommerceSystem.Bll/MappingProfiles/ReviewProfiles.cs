using AutoMapper;
using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.MappingProfiles;

public class ReviewProfiles : Profile
{
    public ReviewProfiles()
    {
        CreateMap<Review, ReviewDto>().ReverseMap();
        CreateMap<Review, ReviewCreateDto>().ReverseMap();
        CreateMap<Review, ReviewUpdateDto>().ReverseMap();
    }
}
