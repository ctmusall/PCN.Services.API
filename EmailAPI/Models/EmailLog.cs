using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Email.API.Models
{
    public class EmailLog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime DateTimeSent { get; set; }
        public bool IsBodyHtml { get; set; }
        public string Priority { get; set; }
        public List<EmailContact> EmailContacts { get; set; }
    }
}
