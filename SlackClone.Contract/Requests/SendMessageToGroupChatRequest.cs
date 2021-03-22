using System;

namespace SlackClone.Contract.Requests
{
    public class SendMessageToGroupChatRequest :
        IRequest
    {
        public string Text { get; set; }
        public Guid CreatorId { get; set; }
        public Guid ChannelId { get; set; }
    }
}
