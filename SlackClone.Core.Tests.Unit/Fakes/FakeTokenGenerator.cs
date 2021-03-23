using SlackClone.Contract.Dtos;
using SlackClone.Core.Models;
using SlackClone.Core.Services;

namespace SlackClone.Core.Tests.Unit.Fakes
{
    public class FakeTokenGenerator :
        ITokenGenerator
    {
        public TokenDto Returns { get; set; }

        public TokenDto Generate(User user)
            => Returns;
    }
}
