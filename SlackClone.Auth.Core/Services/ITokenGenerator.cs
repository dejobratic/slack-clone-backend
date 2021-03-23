using SlackClone.Auth.Core.Models;
using SlackClone.Contract.Dtos;

namespace SlackClone.Auth.Core.Services
{
    public interface ITokenGenerator
    {
        TokenDto Generate(User user);
    }
}
