using AutoMapper;
using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem_.Dal.Entities;

namespace e_CommerceSystem.Bll.MappingProfiles;

public class ProductProfiles : Profile
{
    public ProductProfiles()
    {
        CreateMap<ProductCreateDto, Product>().ReverseMap();
        CreateMap<ProductDto, Product>().ReverseMap();
        CreateMap<ProductUpdateDto, Product>().ReverseMap();
    }
}
