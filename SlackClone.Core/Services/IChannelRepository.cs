using SlackClone.Core.Models;
using System;
using System.Threading.Tasks;

namespace SlackClone.Core.Services
{
    public interface IChannelRepository
    {
        Task<Channel[]> Get();
        Task<Channel> Get(Guid id);
        Task Save(Channel channel);
    }
}
