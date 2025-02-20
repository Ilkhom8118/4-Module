using AutoMapper;
using e_CommerceSystem.Bll.DTOs;

namespace e_CommerceSystem.Bll.MappingProfiles;

public class ProductProfiles : Profile
{
    public ProductProfiles()
    {
        CreateMap<ProductCreateDto, ProductDto>().ReverseMap();
    }
}
