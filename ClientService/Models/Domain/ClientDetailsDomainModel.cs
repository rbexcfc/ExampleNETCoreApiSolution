using System;

namespace ClientService.Models.Domain
{
    public class ClientDetailsDomainModel
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string EmailAddress { get; }

        public ClientDetailsDomainModel(Guid id, string firstName, string lastName, string emailAddress)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
        }
    }
}
