using SlackClone.Contract.Requests;
using SlackClone.Core.Models;
using SlackClone.Core.Services;

namespace SlackClone.Core.UseCases
{
    public class RemoveSubscriberFromChannelCommand :
        BaseChannelSubscriberCommand<RemoveSubscriberFromChannelRequest>
    {
        public RemoveSubscriberFromChannelCommand(
            RemoveSubscriberFromChannelRequest request, 
            IChannelRepository channelRepo) 
            : base(request, channelRepo)
        {
        }

        protected override void UpdateChannelSubscribers(
            Channel channel)
        {
            channel.SubscriberIds.Remove(_request.SubscriberId);
        }
    }
}
