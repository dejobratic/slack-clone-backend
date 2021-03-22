using Microsoft.AspNetCore.Mvc;
using SlackClone.Core.Extensions;
using SlackClone.Core.Services;
using System.Linq;
using System.Threading.Tasks;

namespace SlackClone.Web.Controllers
{
    [Route("/api/channels")]
    public class ChannelController :
        ControllerBase
    {
        private readonly IChannelRepository _repo;

        public ChannelController(
            IChannelRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetChannels()
        {
            var channels = await _repo.Get();
            return Ok(channels.Select(c => c.ToContractModel()));
        }
    }
}
