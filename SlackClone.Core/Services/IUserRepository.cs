using SlackClone.Core.Models;
using System.Threading.Tasks;

namespace SlackClone.Core.Services
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
        Task Save(User user);
    }
}
