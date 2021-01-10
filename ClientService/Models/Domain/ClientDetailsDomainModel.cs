using System;

namespace ClientService.Models.Domain
{
    public class ClientDetailsDomainModel
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string EmailAddress { get; }
        public PensionTypes PensionType { get; set; }
        public decimal PensionTotal { get; set; }

        public ClientDetailsDomainModel(Guid id, string firstName, string lastName, string emailAddress,
            PensionTypes pensionType, decimal pensionTotal)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            PensionTotal = pensionTotal;
            PensionType = pensionType;
        }
    }
}
