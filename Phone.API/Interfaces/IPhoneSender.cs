using System.Threading.Tasks;
using Phone.API.Models;

namespace Phone.API.Interfaces
{
    public interface IPhoneSender
    {
        Task SendMessage(PhoneMessageRequest phoneMessageRequest);
    }
}
