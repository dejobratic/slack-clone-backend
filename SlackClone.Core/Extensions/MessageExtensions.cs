using SlackClone.Contract.Dtos;
using SlackClone.Core.Models;

namespace SlackClone.Core.Extensions
{
    public static class MessageExtensions
    {
        public static MessageDto ToContractModel(
            this Message message)
        {
            return new MessageDto
            {
                Id = message.Id,
                Text = message.Text,
                CreatorId = message.CreatorId,
                CreatedAt = message.CreatedAt,
                ChannelId = message.ChannelId
            };
        }
    }
}
