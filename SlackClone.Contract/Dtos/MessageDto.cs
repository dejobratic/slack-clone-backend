using System;

namespace SlackClone.Contract.Dtos
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public UserDto Creator { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public Guid ChannelId { get; set; }
    }
}
