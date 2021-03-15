using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SlackClone.Web.Hubs;
using SlackClone.Web.Hubs.Clients;
using SlackClone.Web.Models;
using System;
using System.Threading.Tasks;

namespace SlackClone.Web.Controllers
{
    public class ChannelController :
        ControllerBase
    {
        private readonly IHubContext<ChannelHub, IChannelClient> _hub;

        public ChannelController(
            IHubContext<ChannelHub, IChannelClient> hub)
        {
            _hub = hub;
        }

        [HttpPost]
        [Route("/api/channels")]
        public async Task CreateChannel(
            [FromBody] CreateChannelRequest request)
        {
            var channel = new ChatChannel
            {
                Id = Guid.NewGuid(),
                Name = request.ChannelName
            };

            await _hub.Clients.All.CreateChannel(channel);
        }

        public class CreateChannelRequest
        {
            public string ChannelName { get; set; }
        }
    }
}
