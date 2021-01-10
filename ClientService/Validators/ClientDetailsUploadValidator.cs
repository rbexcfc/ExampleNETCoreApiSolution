using ClientService.Models.Information;
using FluentValidation;
using System;

namespace ClientService.Validators
{
    public class ClientDetailsUploadValidator : AbstractValidator<ClientDetailsFormInformation>
    {
        public ClientDetailsUploadValidator()
        {
            RuleFor(v => v.ClientDetailsForm)
            .Cascade(CascadeMode.Stop)
            .Must(f => f.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase)).WithMessage("Only CSV files can be uploaded.")
            .Must(f => f.Length > 0).WithMessage("The uploaded file is empty.")
            .Must(f => f.Length <= 1024 * 256).WithMessage("The uploaded file too large. Maximum size allowed is 256KiB.");
        }
    }
}
