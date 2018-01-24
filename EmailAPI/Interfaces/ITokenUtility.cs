using System.Threading.Tasks;

namespace Email.API.Interfaces
{
    public interface ITokenUtility
    {
        Task<string> GenerateToken(string applicationName);
    }
}
