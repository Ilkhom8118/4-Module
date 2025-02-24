using AutoMapper;
using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.MappingProfiles
{
    public class CartProfiles : Profile
    {
        public CartProfiles()
        {
            CreateMap<Cart, CartCreateDto>().ReverseMap();
            CreateMap<Cart, CartDto>().ReverseMap();
        }
    }
}
