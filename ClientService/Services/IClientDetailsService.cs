using ClientService.Models.Domain;
using ClientService.Models.Information;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientService.Services
{
    public interface IClientDetailsService
    {
        Task<IEnumerable<ClientDetailsDomainModel>> GetAsync();
        Task<ClientDetailsDomainModel> GetAsync(Guid clientId);
        Task SaveAsync(ClientDetailsInformation clientDetails);
        Task DeleteAsync(Guid clientId);
    }
}
