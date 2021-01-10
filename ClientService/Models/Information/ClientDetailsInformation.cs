using System;

namespace ClientService.Models.Information
{
    public class ClientDetailsInformation
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public PensionTypes PensionType { get; set; }
        public decimal PensionTotal { get; set; }
    }
}
