using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SlackClone.Contract.Requests;
using SlackClone.Core.Extensions;
using SlackClone.Core.Models;
using SlackClone.Core.Services;
using SlackClone.Web.Hubs;
using SlackClone.Web.Hubs.Clients;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SlackClone.Web.Controllers
{
    [ApiController]
    [Route("/api/chats/messages")]
    public class ChatController :
        ControllerBase
    {
        private readonly IChatRepository _repo;
        private readonly IHubContext<ChatHub, IChatClient> _hub;

        public ChatController(
            IChatRepository repo,
            IHubContext<ChatHub, IChatClient> hub)
        {
            _repo = repo;
            _hub = hub;
        }

        [HttpGet]
        public async Task<IActionResult> GetChannelMessages(
            [FromQuery] Guid channelId,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize)
        {
            var specification = new MessageSpecification
            {
                ChannelId = channelId,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var messages = await _repo.GetBy(specification);
            return Ok(messages.Select(m => m.ToContractModel()));
        }

        [HttpPost]
        public async Task SendMessage(
            [FromBody] CreateMessageRequest request)
        {
            var message = new Message
            {
                Id = Guid.NewGuid(),
                Text = request.Text,
                CreatedAt = DateTime.UtcNow,
                CreatorId = request.CreatorId,
                ChannelId = request.ChannelId,
            };

            await _repo.Save(message);
            await _hub.Clients.All.ReceiveMessage(message.ToContractModel());
        }
    }
}
