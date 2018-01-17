using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Email.API.Models
{
    public class EmailContact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public string DisplayName { get; set; }

        [ForeignKey("EmailLog")]
        public Guid EmailLogId { get; set; }

        public string ContactType { get; set; }

        public EmailLog EmailLog { get; set; }
    }
}
