using ClientService.Models;
using ClientService.Models.Information;
using FluentValidation;

namespace ClientService.Validators
{
    public class CreateClientDetailsValidator : AbstractValidator<ClientDetailsInformation>
    {
        public CreateClientDetailsValidator()
        {
            RuleFor(x => x.Id).NotEmpty()
                .WithMessage("Id must not be empty");
            RuleFor(x => x.FirstName).NotEmpty()
                .WithMessage("First Name must not be empty");
            RuleFor(x => x.LastName).NotEmpty()
                .WithMessage("Last Name must not be empty");
            RuleFor(x => x.EmailAddress)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email address is invalid");
            RuleFor(x => x.PensionType).IsInEnum()
                .WithMessage("Pension Type is invalid");
            RuleFor(x => x.PensionTotal).NotEmpty()
               .WithMessage("Pension total is invalid");
        }
    }
}
