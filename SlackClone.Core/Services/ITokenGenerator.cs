using SlackClone.Contract.Dtos;
using SlackClone.Core.Models;

namespace SlackClone.Core.Services
{
    public interface ITokenGenerator
    {
        TokenDto Generate(User user);
    }
}
