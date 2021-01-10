using AutoMapper;
using ClientService.Controllers;
using ClientService.Exceptions;
using ClientService.Mappings;
using ClientService.Models.Domain;
using ClientService.Models.Information;
using ClientService.Services;
using ClientService.Validators;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ClientServiceTests.Validators
{
    public class CreateClientDetailsValidatorTests
    {
        private readonly CreateClientDetailsValidator _validator;

        public CreateClientDetailsValidatorTests()
        {
            _validator = new CreateClientDetailsValidator();
        }

        [Theory(DisplayName = @"GIVEN an invalid FirstName
WHEN it is validated
THEN it fails validation")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Validate_WithInvalidFirstName_CausesValidationError(string firstName)
        {
            var result = _validator.Validate(new ClientDetailsInformation { Id = Guid.NewGuid(), FirstName = firstName, LastName = "Test", EmailAddress = "Test@Test.com" });
            result.Should().NotBeNull();
            result.IsValid.Should().BeFalse();
            result.Errors[0].ErrorMessage.Should().Be("First Name must not be empty");
        }

        [Theory(DisplayName = @"GIVEN an invalid Email
WHEN it is validated
THEN it fails validation")]
        [InlineData("test123")]
        [InlineData("test123@")]
        public void Validate_WithInvalidEmail_CausesValidationError(string email)
        {
            var result = _validator.Validate(new ClientDetailsInformation { Id = Guid.NewGuid(), FirstName = "Test", LastName = "Test", EmailAddress = email });
            result.Should().NotBeNull();
            result.IsValid.Should().BeFalse();
            result.Errors[0].ErrorMessage.Should().Be("Email address is invalid");
        }
    }
}
