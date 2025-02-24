using AutoMapper;
using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.MappingProfiles
{
    public class PaymentProfiles : Profile
    {
        public PaymentProfiles()
        {
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Payment, PaymentCreateDto>().ReverseMap();
            CreateMap<Payment, PaymentUpdateDto>().ReverseMap();
        }
    }
}
