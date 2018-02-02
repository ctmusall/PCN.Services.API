using System.Threading.Tasks;

namespace Services.Portal.Interfaces
{
    public interface IPhoneTokenUtility
    {
        Task<string> GetPhoneToken();
    }
}
