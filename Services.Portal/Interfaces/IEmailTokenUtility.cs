using System.Threading.Tasks;

namespace Services.Portal.Interfaces
{
    public interface IEmailTokenUtility
    {
        Task<string> GetEmailToken();
    }
}
