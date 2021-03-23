using System;

namespace SlackClone.Core.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Guid ChannelId { get; set; }
        public Guid CreatorId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
