using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phone.API.Models
{
    public class PhoneContact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("PhoneLog")]
        public Guid PhoneLogId { get; set; }
        public PhoneLog PhoneLog { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
    }
}
