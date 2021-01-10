using System;
using System.ComponentModel.DataAnnotations;

namespace ClientService.Models.Entity
{
    public class ClientDetailsEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
    }
}
