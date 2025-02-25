using AutoMapper;
using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Dal.Entities;

namespace CarRendalSystem.Bll.MappingProfile;

public class PaymentProfiles : Profile
{
    public PaymentProfiles()
    {
        CreateMap<Payment, PaymentGetDto>().ReverseMap();
        CreateMap<Payment, PaymentCreateDto>().ReverseMap();
        CreateMap<Payment, PaymentUpdateDto>().ReverseMap();
    }
}
