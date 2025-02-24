using AutoMapper;
using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.MappingProfiles;

public class OrderProfiles : Profile
{
    public OrderProfiles()
    {
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<Order, OrderCreateDto>().ReverseMap();
        CreateMap<Order, OrderUpdateDto>().ReverseMap();
    }
}
