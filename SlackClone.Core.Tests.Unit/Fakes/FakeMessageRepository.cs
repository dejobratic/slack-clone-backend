using SlackClone.Core.Models;
using SlackClone.Core.Services;
using System.Threading.Tasks;

namespace SlackClone.Core.Tests.Unit.Fakes
{
    public class FakeMessageRepository :
        IMessageRepository
    {
        public Message[] Returns { get; set; }
        public Message Saved { get; private set; }

        public Task<Message[]> GetBy(MessageSpecification specification)
            => Task.FromResult(Returns);

        public Task Save(Message message)
        {
            Saved = message;
            return Task.CompletedTask;
        }
    }
}
