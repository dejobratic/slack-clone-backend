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
    [Route("/api/channels")]
    public class ChannelController :
        ControllerBase
    {
        private readonly IChannelRepository _repo;
        private readonly IHubContext<ChannelHub, IChannelClient> _hub;

        public ChannelController(
            IChannelRepository repo,
            IHubContext<ChannelHub, IChannelClient> hub)
        {
            _repo = repo;
            _hub = hub;
        }

        [HttpGet]
        public async Task<IActionResult> GetChannels()
        {
            var channels = await _repo.Get();
            return Ok(channels.Select(c => c.ToContractModel()));
        }

        [HttpPost]
        public async Task CreateChannel(
            [FromBody] CreateChannelRequest request)
        {
            var channel = new Channel
            {
                Id = Guid.NewGuid(),
                Name = request.ChannelName
            };

            await _repo.Save(channel);
            await _hub.Clients.All.CreateChannel(channel.ToContractModel());
        }
    }
}
