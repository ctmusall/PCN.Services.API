using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Email.API.Models
{
    public class LoggedEmail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime DateTimeSent { get; set; }
    }
}
