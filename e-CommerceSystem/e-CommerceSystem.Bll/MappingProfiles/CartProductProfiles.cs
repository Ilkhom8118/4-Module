using AutoMapper;
using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.MappingProfiles
{
    public class CartProductProfiles : Profile
    {
        public CartProductProfiles()
        {
            CreateMap<CartProduct, CartProductDto>().ReverseMap();
            CreateMap<CartProduct, CartProductCreateDto>().ReverseMap();
            CreateMap<CartProduct, CartProductUpdateDto>().ReverseMap();
        }
    }
}
