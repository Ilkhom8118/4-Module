using AutoMapper;
using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.MappingProfiles;

public class OrderProductProfiles : Profile
{
    public OrderProductProfiles()
    {
        CreateMap<OrderProduct, OrderProductDto>().ReverseMap();
        CreateMap<OrderProduct, OrderProductCreateDto>().ReverseMap();
        CreateMap<OrderProduct, OrderProductUpdateDto>().ReverseMap();
    }
}
