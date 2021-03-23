using SlackClone.Auth.Core.Models;
using SlackClone.Auth.Core.Services;
using SlackClone.Contract.Dtos;

namespace SlackClone.Auth.Core.Tests.Unit.Fakes
{
    public class FakeTokenGenerator :
        ITokenGenerator
    {
        public TokenDto Returns { get; set; }

        public TokenDto Generate(User user)
            => Returns;
    }
}
