using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Email.API.Models
{
    public class EmailRequest
    {
        [Required]
        public ICollection<EmailContactRequest> To { get; set; }
        [Required]
        public EmailContactRequest From { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }
        public ICollection<EmailContactRequest> Cc { get; set; } 
        public ICollection<EmailContactRequest> Bcc { get; set; }  
        public bool IsBodyHtml { get; set; }
        public string Priority { get; set; }
        // TODO - Attachments
    }
}