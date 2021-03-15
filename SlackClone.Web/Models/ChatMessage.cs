using System;

namespace SlackClone.Web.Models
{
    public class ChatMessage
    {
        public Guid Id { get; set; }
        public object User { get; set; }
        public string Text { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public Guid UserId { get; set; }
    }
}
