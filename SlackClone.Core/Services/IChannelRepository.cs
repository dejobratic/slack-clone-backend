using SlackClone.Core.Models;
using System.Threading.Tasks;

namespace SlackClone.Core.Services
{
    public interface IChannelRepository
    {
        Task<Channel[]> Get();
        Task Save(Channel channel);
    }
}
