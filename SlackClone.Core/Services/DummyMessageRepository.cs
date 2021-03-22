using SlackClone.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlackClone.Core.Services
{
    public class DummyMessageRepository :
        IMessageRepository
    {
        private readonly Dictionary<Guid, List<Message>> _chat;

        public DummyMessageRepository()
        {
            _chat = new Dictionary<Guid, List<Message>>();
        }

        public Task<Message[]> GetBy(MessageSpecification specification)
        {
            var channelId = specification.ChannelId;

            if (_chat.ContainsKey(channelId))
            {
                var messages = _chat[channelId]
                    .OrderByDescending(m => m.CreatedAt)
                    .Skip((specification.PageNumber - 1) * specification.PageSize)
                    .Take(specification.PageSize)
                    .Reverse()
                    .ToArray();

                return Task.FromResult(messages);
            }

            return Task.FromResult(Array.Empty<Message>());
        }

        public Task Save(Message message)
        {
            if (_chat.ContainsKey(message.ChannelId))
            {
                var existing = _chat[message.ChannelId]
                    .FirstOrDefault(m => m.Id == message.Id);

                if (existing is null)
                    return AddToExistingChat(message);

                return UpdateInExistingChat(message);
            }

            return AddToNewChat(message);
        }

        private Task AddToNewChat(Message message)
        {
            _chat.Add(message.ChannelId, new List<Message> { message });
            return Task.CompletedTask;
        }

        private Task AddToExistingChat(Message message)
        {
            var messages = _chat[message.ChannelId];
            messages.Add(message);

            _chat[message.ChannelId] = messages;
            return Task.CompletedTask;
        }

        private Task UpdateInExistingChat(Message message)
        {
            var existing = _chat[message.ChannelId]
                .Single(m => m.Id == message.Id);

            existing.Text = message.Text;
            return Task.CompletedTask;
        }
    }
}
