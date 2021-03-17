using SlackClone.Contract.Dtos;
using SlackClone.Core.Models;

namespace SlackClone.Core.Extensions
{
    public static class ChannelExtensions
    {
        public static ChannelDto ToContractModel(
            this Channel channel)
        {
            return new ChannelDto
            {
                Id = channel.Id,
                Name = channel.Name
            };
        }
    }
}
