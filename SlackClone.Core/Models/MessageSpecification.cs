using System;

namespace SlackClone.Core.Models
{
    public class MessageSpecification
    {
        public Guid ChannelId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
