using System;

namespace SlackClone.Contract.Requests
{
    public class GetSubscribedChannelsRequest :
        IRequest
    {
        public Guid SubscriberId { get; set; }
    }
}
