using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SlackClone.Web.Hubs;
using SlackClone.Web.Hubs.Clients;
using SlackClone.Web.Models;
using System.Threading.Tasks;

namespace SlackClone.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController :
        ControllerBase
    {
        private readonly IHubContext<ChatHub, IChatClient> _hub;

        public ChatController(
            IHubContext<ChatHub, IChatClient> hub)
        {
            _hub = hub;
        }

        [HttpPost]
        [Route("messages")]
        public async Task Post(ChatMessage message)
        {
            await _hub.Clients.All.ReceiveMessage(message);
        }
    }
}
