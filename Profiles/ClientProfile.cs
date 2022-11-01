using AutoMapper;
using SellerERP.Dtos.ClientDto;
using SellerERP.Models;

namespace SellerERP.Profiles;

public class ClientProfile : Profile
{
    public ClientProfile()
    {
        
        CreateMap<Client, ClientReadDto>();
        CreateMap<ClientCreateDto, Client>();
        CreateMap<ClientUpdateDto, Client>();
        CreateMap<Client, ClientUpdateDto>();
    }
}
