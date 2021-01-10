using ClientService.Models.Domain;
using ClientService.Models.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientService.Repositories
{
    public interface IClientDetailsRepository
    {
        Task<IEnumerable<ClientDetailsEntity>> GetAsync();
        Task<ClientDetailsEntity> GetAsync(Guid clientId);
        Task SaveAsync(ClientDetailsDomainModel clientDetailsDomainModel);
        Task DeleteAsync(Guid clientId);
    }
}
