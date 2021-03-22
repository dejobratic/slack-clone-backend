using System;

namespace SlackClone.Contract.Dtos
{
    public class ChannelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
