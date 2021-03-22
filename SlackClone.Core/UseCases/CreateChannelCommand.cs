using SlackClone.Contract.Dtos;
using SlackClone.Contract.Requests;
using SlackClone.Core.Extensions;
using SlackClone.Core.Models;
using SlackClone.Core.Services;
using System;
using System.Threading.Tasks;

namespace SlackClone.Core.UseCases
{
    public class CreateChannelCommand :
        ICommand<ChannelDto>
    {
        private readonly CreateChannelRequest _request;
        private readonly ITimestampProvider _timestampProvider;
        private readonly IChannelRepository _channelRepo;

        public CreateChannelCommand(
            CreateChannelRequest request, 
            ITimestampProvider timestampProvider, 
            IChannelRepository channelRepo)
        {
            _request = request;
            _timestampProvider = timestampProvider;
            _channelRepo = channelRepo;
        }

        public async Task<ChannelDto> Execute()
        {
            Channel channel = CreateChannel();
            await _channelRepo.Save(channel);

            return channel.ToContractModel();
        }

        private Channel CreateChannel()
        {
            return new Channel
            {
                Id = Guid.NewGuid(),
                Name = _request.Name,
                Description = _request.Description,
                CreatorId = _request.CreatorId,
                CreatedAt = _timestampProvider.Provide()
            };
        }
    }
}
