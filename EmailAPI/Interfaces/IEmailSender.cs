using System.Threading.Tasks;
using Email.API.Models;

namespace Email.API.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmail(EmailRequest loggedEmail);
    }
}
