using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public PensionTypes PensionType { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal PensionTotal { get; set; }
    }
}
