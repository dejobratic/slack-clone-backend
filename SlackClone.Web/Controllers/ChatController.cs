using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SlackClone.Web.Hubs;
using SlackClone.Web.Hubs.Clients;
using SlackClone.Web.Models;
using System;
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
        [Route("/api/chats/messages")]
        public async Task ReceiveMessage(
            [FromBody] CreateMessageRequest request)
        {
            var message = new ChatMessage
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                User = new
                {
                    Name = "Dejan Bratic",
                    Image = "https://www.kindpng.com/picc/m/78-786207_user-avatar-png-user-avatar-icon-png-transparent.png"
                },
                Text = request.Text
            };

            await _hub.Clients.All.ReceiveMessage(message);
        }

        public class CreateMessageRequest
        {
            public string Text { get; set; }
        }
    }
}
