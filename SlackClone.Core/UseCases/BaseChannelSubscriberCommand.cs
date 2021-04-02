using SlackClone.Contract.Dtos;
using SlackClone.Contract.Requests;
using SlackClone.Core.Extensions;
using SlackClone.Core.Models;
using SlackClone.Core.Services;
using System.Threading.Tasks;

namespace SlackClone.Core.UseCases
{
    public abstract class BaseChannelSubscriberCommand<T> :
        ICommand<ChannelDto>
        where T : BaseChannelSubscriberRequest
    {
        protected readonly T _request;
        protected readonly IChannelRepository _channelRepo;

        protected BaseChannelSubscriberCommand(
            T request, 
            IChannelRepository channelRepo)
        {
            _request = request;
            _channelRepo = channelRepo;
        }

        public async Task<ChannelDto> Execute()
        {
            Channel channel = await _channelRepo
                .Get(_request.ChannelId);

            UpdateChannelSubscribers(channel);
            await _channelRepo.Save(channel);

            return channel.ToContractModel();
        }

        protected abstract void UpdateChannelSubscribers(Channel channel);
    }
}
