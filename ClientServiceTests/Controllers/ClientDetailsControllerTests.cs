using AutoMapper;
using ClientService.Controllers;
using ClientService.Exceptions;
using ClientService.Mappings;
using ClientService.Models;
using ClientService.Models.Domain;
using ClientService.Models.Information;
using ClientService.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ClientServiceTests
{
    public class ClientDetailsControllerTests
    {
        private readonly ClientDetailsController _controller;
        private readonly Mock<IClientDetailsService> _clientDetailsServiceMock;
        private readonly Mock<IClientDetailsUploader> _clientDetailsUploaderMock;
        private readonly IMapper _mapper;

        public ClientDetailsControllerTests()
        {    
            _clientDetailsServiceMock = new Mock<IClientDetailsService>();
            _clientDetailsUploaderMock = new Mock<IClientDetailsUploader>();
            _mapper = new Mapper(new MapperConfiguration(mcf => mcf.AddProfile<ClientDetailsProfile>()));

            _controller = new ClientDetailsController(_clientDetailsServiceMock.Object, _clientDetailsUploaderMock.Object, _mapper);
        }

        [Fact(DisplayName = @"GIVEN a valid client Id
WHEN a request is made to get the client details by that ID
THEN the client details are returned ")]
        public async void Get_WithValidClientId_ReturnsInformation()
        {
            var clientId = Guid.NewGuid();
            var firstName = "Richie";
            var lastName = "Bexhell";
            var email = "test@test.com";
            var pensionType = PensionTypes.Nest;
            var pensionTotals = 1000m;

            var clientDetails = new ClientDetailsDomainModel(clientId, firstName, lastName, email, pensionType, pensionTotals);

            _clientDetailsServiceMock.Setup(m => m.GetAsync(clientId)).ReturnsAsync(clientDetails);

            var result = await _controller.GetById(clientId);

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();
            result.Value.FirstName.Should().Be(firstName);
            result.Value.LastName.Should().Be(lastName);
            result.Value.EmailAddress.Should().Be(email);
            result.Value.PensionType.Should().Be(pensionType);
            result.Value.PensionTotal.Should().Be(pensionTotals);
        }

        [Fact(DisplayName = @"GIVEN a valid client Id
WHEN a request is made to delete the client details by that ID
THEN the client details are deleted ")]
        public async void Delete_WithValidClientId_ReturnsNoContent()
        {
            var clientId = Guid.NewGuid();

            _clientDetailsServiceMock.Setup(m => m.DeleteAsync(clientId)).Returns(Task.CompletedTask);

            var result = await _controller.Delete(clientId);

            result.Should().BeEquivalentTo(new NoContentResult());
        }

        [Fact(DisplayName = @"GIVEN valid client details
WHEN a request is made to save these client details
THEN the client details are saved ")]
        public async void Save_WithValidClientDetails_ReturnsNoContent()
        {
            var clientId = Guid.NewGuid();
            _clientDetailsServiceMock.Setup(m => m.SaveAsync(It.Is<ClientDetailsInformation>(m => m != null && m.Id == clientId)))
                .Verifiable();

            var result = await _controller.Save(new ClientDetailsInformation() {Id = clientId, FirstName = "Test",
                LastName = "McTestFace", EmailAddress = "Test@Test.com" });

            result.Should().BeEquivalentTo(new NoContentResult());
        }

        [Fact(DisplayName = @"GIVEN an Invalid client Id
WHEN a request is made to get the client details by that ID
THEN a NotFound result is returned")]
        public async void Get_WithInValidClientId_ReturnsNotFound()
        {
            var clientId = Guid.NewGuid();

            _clientDetailsServiceMock.Setup(m => m.GetAsync(clientId)).ThrowsAsync(new NotFoundException($"No client details found by the given Client Id ({clientId})."));

            var result = await _controller.GetById(clientId);

            result.Result.Should().BeEquivalentTo(new NotFoundResult());
        }
    }
}
