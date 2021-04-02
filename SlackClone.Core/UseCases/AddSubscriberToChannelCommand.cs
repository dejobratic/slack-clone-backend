using SlackClone.Contract.Requests;
using SlackClone.Core.Models;
using SlackClone.Core.Services;

namespace SlackClone.Core.UseCases
{
    public class AddSubscriberToChannelCommand :
        BaseChannelSubscriberCommand<AddSubscriberToChannelRequest>
    {
        public AddSubscriberToChannelCommand(
            AddSubscriberToChannelRequest request, 
            IChannelRepository channelRepo)
            : base(request, channelRepo)
        {
        }

        protected override void UpdateChannelSubscribers(
            Channel channel)
        {
            channel.SubscriberIds.Add(_request.SubscriberId);
        }
    }
}
