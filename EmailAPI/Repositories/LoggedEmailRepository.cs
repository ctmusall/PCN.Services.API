using System;
using System.Collections.Generic;
using Email.API.Interfaces;
using Email.API.Models;

namespace Email.API.Repositories
{
    public class LoggedEmailRepository : ILoggedEmailRepository
    {
        public List<LoggedEmail> RetrieveAllLoggedEmails()
        {
            return new List<LoggedEmail>
            {
                new LoggedEmail { Id = new Guid("2d083541-1665-427b-830a-ac99d9510328"), DateTimeSent = DateTime.Now, FromAddress = "cmusall@pcnclosings.com", ToAddress = "cmusall@pcnclosings.com", Subject = "Hello World!", Message = "Hello from the email web API!"},
                new LoggedEmail { Id = new Guid("72d67fe2-4463-41f1-a8e6-6210dce74ee1"), DateTimeSent = DateTime.Now, FromAddress = "cmusall@pcnclosings.com", ToAddress = "helloworld@pcnclosings.com", Subject = "Hello World!", Message = "Hello from the email web API!"}
            };
        }
    }
}
