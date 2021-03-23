using System;

namespace SlackClone.Contract.Requests
{
    public class GetChannelMessagesRequest : 
        IRequest
    {
        public Guid ChannelId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
