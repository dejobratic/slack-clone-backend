using SlackClone.Core.Models;
using SlackClone.Core.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SlackClone.Core.Tests.Unit.Fakes
{
    public class FakeChannelRepository :
        IChannelRepository
    {
        public Channel[] Returns { get; set; }

        public Channel Saved { get; private set; }

        public Task<Channel[]> Get()
            => Task.FromResult(Returns);

        public Task<Channel> Get(Guid id)
            => Task.FromResult(Returns.SingleOrDefault());

        public Task Save(Channel channel)
        {
            Saved = channel;
            return Task.CompletedTask;
        }
    }
}
