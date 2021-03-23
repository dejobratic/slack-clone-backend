using SlackClone.Contract.Dtos;
using SlackClone.Contract.Requests;
using SlackClone.Core.Extensions;
using SlackClone.Core.Models;
using SlackClone.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlackClone.Core.UseCases
{
    public class GetSubscribedChannelsCommand :
        ICommand<IEnumerable<ChannelDto>>
    {
        private readonly GetSubscribedChannelsRequest _request;
        private readonly IChannelRepository _channelRepo;

        public GetSubscribedChannelsCommand(
            GetSubscribedChannelsRequest request,
            IChannelRepository channelRepo)
        {
            _request = request;
            _channelRepo = channelRepo;
        }

        public async Task<IEnumerable<ChannelDto>> Execute()
        {
            // TODO: add logic that looks for subscribed channels
            IEnumerable<Channel> channels = await _channelRepo.Get();

            return channels.Select(c => c.ToContractModel());
        }
    }
}
