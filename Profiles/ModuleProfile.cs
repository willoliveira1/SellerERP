using AutoMapper;
using SellerERP.Dtos.ModuleDto;
using SellerERP.Models;

namespace SellerERP.Profiles;

public class ModuleProfile : Profile
{
    public ModuleProfile()
    {
        CreateMap<Module, ModuleReadDto>();
        CreateMap<ModuleCreateDto, Module>();
        CreateMap<ModuleUpdateDto, Module>();
        CreateMap<Module, ModuleUpdateDto>();
    }
}
