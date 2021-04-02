using SlackClone.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlackClone.Core.Services
{
    public class DummyChannelRepository :
        IChannelRepository
    {
        private readonly List<Channel> _channels;

        public DummyChannelRepository()
        {
            _channels = new List<Channel>();
        }

        public Task<Channel[]> Get()
            => Task.FromResult(_channels.ToArray());

        public Task<Channel> Get(Guid id)
        {
            var channel = _channels.SingleOrDefault(c => c.Id == id);

            if(channel is null)
                throw new Exception($"No channel found.");

            return Task.FromResult(channel);
        }

        public Task Save(Channel channel)
        {
            var existing = _channels.FirstOrDefault(c => c.Id == channel.Id);

            if (existing is null)
                return AddNew(channel);

            return UpdateExisting(channel);
        }

        private Task AddNew(Channel channel)
        {
            var existing = _channels.FirstOrDefault(c => c.Name == channel.Name);

            if (existing is null)
            {
                _channels.Add(channel);
                return Task.CompletedTask;
            }

            var exception = new Exception($"Channel with name {channel.Name} already exists.");
            return Task.FromException(exception);
        }

        private Task UpdateExisting(Channel channel)
        {
            var existing = _channels.Single(c => c.Id == channel.Id);

            existing.Name = channel.Name;

            return Task.CompletedTask;
        }
    }
}
