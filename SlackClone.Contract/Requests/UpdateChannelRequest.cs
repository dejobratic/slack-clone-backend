using System;

namespace SlackClone.Contract.Requests
{
    public class UpdateChannelRequest :
        IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
