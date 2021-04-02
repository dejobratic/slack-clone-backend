using System;

namespace SlackClone.Contract.Requests
{
    public class BaseChannelSubscriberRequest
    {
        public Guid ChannelId { get; set; }
        public Guid SubscriberId { get; set; }
    }
}
