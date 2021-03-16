using SlackClone.Core.Models;
using System.Threading.Tasks;

namespace SlackClone.Core.Services
{
    public interface IChatRepository
    {
        Task<Message[]> GetBy(MessageSpecification specification);
        Task Save(Message message);
    }
}
