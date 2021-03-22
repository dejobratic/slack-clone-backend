using System;

namespace SlackClone.Contract.Requests
{
    public class CreateChannelRequest :
        IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CreatorId { get; set; }
    }
}
