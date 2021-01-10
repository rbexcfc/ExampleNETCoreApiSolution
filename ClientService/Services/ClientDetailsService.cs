using AutoMapper;
using ClientService.Models.Domain;
using ClientService.Models.Information;
using ClientService.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientService.Services
{
    public class ClientDetailsService : IClientDetailsService
    {
        private readonly IClientDetailsRepository _clientDetailsRepository;
        private readonly IMapper _mapper;

        public ClientDetailsService(IClientDetailsRepository clientDetailsRepository, IMapper mapper)
        {
            _clientDetailsRepository = clientDetailsRepository;
            _mapper = mapper;
        }

        public async Task<ClientDetailsDomainModel> GetAsync(Guid clientId)
        {
            var entity = await _clientDetailsRepository.GetAsync(clientId);
            return _mapper.Map<ClientDetailsDomainModel>(entity);
        }

        public async Task<IEnumerable<ClientDetailsDomainModel>> GetAsync()
        {
            var entity = await _clientDetailsRepository.GetAsync();
            return _mapper.Map<IEnumerable<ClientDetailsDomainModel>>(entity);
        }

        public async Task SaveAsync(ClientDetailsInformation clientDetails)
        {
            var domainModel = _mapper.Map<ClientDetailsDomainModel>(clientDetails);
            await _clientDetailsRepository.SaveAsync(domainModel);
        }

        public async Task DeleteAsync(Guid clientId) => await _clientDetailsRepository.DeleteAsync(clientId);
    }
}
