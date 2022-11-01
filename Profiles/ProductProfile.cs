using AutoMapper;
using SellerERP.Dtos.ProductDto;
using SellerERP.Models;

namespace SellerERP.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductReadDto>();
        CreateMap<ProductCreateDto, Product>();
        CreateMap<ProductUpdateDto, Product>();
        CreateMap<Product, ProductUpdateDto>();
    }
}
