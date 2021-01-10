using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using ClientService.Exceptions;
using ClientService.Models.Information;
using ClientService.Services;
using System.Collections.Generic;

namespace ClientService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientDetailsController : ControllerBase
    {
        private readonly IClientDetailsService _clientDetailsService;
        private readonly IClientDetailsUploader _clientDetailsUploader;
        private readonly IMapper _mapper;

        public ClientDetailsController(IClientDetailsService clientDetailsService,
            IClientDetailsUploader clientDetailsUploader, IMapper mapper)
        {
            _clientDetailsService = clientDetailsService;
            _clientDetailsUploader = clientDetailsUploader;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ClientDetailsInformation>>> Get()
        {
            try
            {
                var clientList = await _clientDetailsService.GetAsync();
                var informationList = _mapper.Map<IEnumerable<ClientDetailsInformation>>(clientList);

                return Ok(informationList);
            }

            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ClientDetailsInformation), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClientDetailsInformation>> GetById([FromRoute] Guid id)
        {
            try
            {
                var clientDetails = await _clientDetailsService.GetAsync(id);
                var information = _mapper.Map<ClientDetailsInformation>(clientDetails);

                return information;
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Save([FromBody] ClientDetailsInformation clientDetails)
        {
            await _clientDetailsService.SaveAsync(clientDetails);
            return NoContent();
        }

        [HttpPost]
        [Route("upload")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Upload([FromForm] ClientDetailsFormInformation clientDetailsForm)
        {
            try
            {
                await _clientDetailsUploader.UploadClientDetails(clientDetailsForm);
                return NoContent();
            }
            catch (BlobExistsException)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _clientDetailsService.DeleteAsync(id);
            return NoContent();
        }
    }
}
