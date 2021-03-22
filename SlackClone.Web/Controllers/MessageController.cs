using Microsoft.AspNetCore.Mvc;
using SlackClone.Core.Extensions;
using SlackClone.Core.Models;
using SlackClone.Core.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SlackClone.Web.Controllers
{
    [ApiController]
    [Route("/api/messages")]
    public class MessageController :
        ControllerBase
    {
        private readonly IMessageRepository _repo;

        public MessageController(
            IMessageRepository repo)
        {
            _repo = repo;
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
    }
}
