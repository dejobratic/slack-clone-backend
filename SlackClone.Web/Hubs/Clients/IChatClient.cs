using SlackClone.Web.Models;
using System.Threading.Tasks;

namespace SlackClone.Web.Hubs.Clients
{
    public interface IChatClient
    {
        Task ReceiveMessage(ChatMessage message);
    }
}
