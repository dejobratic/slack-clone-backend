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
                Creator = new UserDto
                {
                    Name = "Dejan Bratic",
                    ImageUrl = "https://www.kindpng.com/picc/m/78-786207_user-avatar-png-user-avatar-icon-png-transparent.png"
                },
                CreatedAt = message.CreatedAt,
                ChannelId = message.ChannelId
            };
        }
    }
}
