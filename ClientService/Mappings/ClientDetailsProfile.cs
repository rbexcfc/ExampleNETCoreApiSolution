using AutoMapper;
using ClientService.Models.Domain;
using ClientService.Models.Entity;
using ClientService.Models.Information;

namespace ClientService.Mappings
{
    public class ClientDetailsProfile : Profile
    {
        public ClientDetailsProfile()
        {
            CreateMap<ClientDetailsDomainModel, ClientDetailsEntity>().ReverseMap();
            CreateMap<ClientDetailsInformation, ClientDetailsDomainModel>().ReverseMap();
        }
    }
}
