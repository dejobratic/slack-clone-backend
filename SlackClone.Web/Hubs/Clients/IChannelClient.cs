using SlackClone.Contract.Dtos;
using System.Threading.Tasks;

namespace SlackClone.Web.Hubs.Clients
{
    public interface IChannelClient
    {
        Task CreateChannel(ChannelDto channel);
    }
}
