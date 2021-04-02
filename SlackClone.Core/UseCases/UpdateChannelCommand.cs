using SlackClone.Contract.Dtos;
using SlackClone.Contract.Requests;
using SlackClone.Core.Extensions;
using SlackClone.Core.Models;
using SlackClone.Core.Services;
using System.Threading.Tasks;

namespace SlackClone.Core.UseCases
{
    public class UpdateChannelCommand :
        ICommand<ChannelDto>
    {
        private readonly UpdateChannelRequest _request;
        private readonly IChannelRepository _channelRepo;

        public UpdateChannelCommand(
            UpdateChannelRequest request, 
            IChannelRepository channelRepo)
        {
            _request = request;
            _channelRepo = channelRepo;
        }

        public async Task<ChannelDto> Execute()
        {
            Channel channel = await _channelRepo
                .Get(_request.Id);

            channel.Name = _request.Name;
            channel.Description = _request.Description;

            await _channelRepo.Save(channel);

            return channel.ToContractModel();
        }
    }
}
