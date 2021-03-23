using SlackClone.Auth.Core.Models;
using System.Threading.Tasks;

namespace SlackClone.Auth.Core.Services
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
        Task Save(User user);
    }
}
