using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using AutoMapper;
using ClientService.Models.Domain;
using ClientService.Models.Entity;
using ClientService.Models;
using ClientService.Exceptions;
using System.Collections.Generic;

namespace ClientService.Repositories
{
    public class ClientDetailsRepository : IClientDetailsRepository
    {
        private readonly ClientContext _context;
        private readonly IMapper _mapper;

        public ClientDetailsRepository(ClientContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ClientDetailsEntity> GetAsync(Guid clientId)
        {
            var clientDetails = await _context.ClientDetails.SingleOrDefaultAsync(e => e.Id == clientId);
            if (clientDetails == null)
            {
                throw new NotFoundException($"No client details found by the given Client Id ({clientId}).");
            }

            return clientDetails;
        }

        public async Task<IEnumerable<ClientDetailsEntity>> GetAsync()
        {
            var clientDetailList = await _context.ClientDetails.ToListAsync();
            if (clientDetailList.Count == 0)
            {
                throw new NotFoundException($"No client details were found.");
            }

            return clientDetailList;
        }

        public async Task SaveAsync(ClientDetailsDomainModel clientDetailsDomainModel)
        {
            var clientDetails = await _context.ClientDetails.SingleOrDefaultAsync(e => e.Id == clientDetailsDomainModel.Id);
            var entity = _mapper.Map<ClientDetailsEntity>(clientDetailsDomainModel);
            if (clientDetails == null)
            {
                _context.ClientDetails.Add(entity);
            }
            else
            {
                clientDetails.FirstName = entity.FirstName;
                clientDetails.LastName = entity.LastName;
                clientDetails.EmailAddress = entity.EmailAddress;
                clientDetails.PensionType = entity.PensionType;
                clientDetails.PensionTotal = entity.PensionTotal;
            }
         
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid clientId)
        {
            var clientDetails = await _context.ClientDetails.SingleOrDefaultAsync(e => e.Id == clientId);
            if (clientDetails == null)
            {
                throw new NotFoundException($"No client details found by the given Client Id ({clientId}).");
            }
            _context.ClientDetails.Remove(clientDetails);
            await _context.SaveChangesAsync();
        }
    }
}
