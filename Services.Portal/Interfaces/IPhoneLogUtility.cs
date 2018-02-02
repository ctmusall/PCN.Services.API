using System.Threading.Tasks;

namespace Services.Portal.Interfaces
{
    public interface IPhoneLogUtility
    {
        Task<string> GetMessages(string token);
    }
}
