using System;

namespace Email.API.Models
{
    public class LoggedEmail
    {
        public Guid Id { get; set; }
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime DateTimeSent { get; set; }
    }
}
