using SlackClone.Core.Models;
using System.Threading.Tasks;

namespace SlackClone.Core.Services
{
    public interface IMessageRepository
    {
        Task<Message[]> GetBy(MessageSpecification specification);
        Task Save(Message message);
    }
}
