using SlackClone.Core.Models;
using SlackClone.Core.Services;
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

        public Task Save(Channel channel)
        {
            Saved = channel;
            return Task.CompletedTask;
        }
    }
}
