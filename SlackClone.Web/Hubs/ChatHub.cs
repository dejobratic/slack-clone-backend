using Microsoft.AspNetCore.SignalR;
using SlackClone.Web.Hubs.Clients;

namespace SlackClone.Web.Hubs
{
    public class ChatHub :
        Hub<IChatClient>
    {
        //public async Task SendMessage(ChatMessage message)
        //{
        //    await Clients.All.ReceiveMessage(message);
        //}
    }
}
