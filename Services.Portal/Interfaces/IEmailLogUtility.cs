using System.Threading.Tasks;

namespace Services.Portal.Interfaces
{
    public interface IEmailLogUtility
    {
        Task<string> GetEmails(string token);
    }
}
