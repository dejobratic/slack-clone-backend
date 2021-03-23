using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClone.Auth.Core.Services;
using SlackClone.Auth.Core.Tests.Unit.Fakes;
using System.Threading.Tasks;

namespace SlackClone.Auth.Core.Tests.Unit.Services
{
    [TestClass]
    [TestCategory("Unit")]
    public class DummyUserRepositoryTests
    {
        private DummyUserRepository _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new DummyUserRepository();
        }

        [TestMethod]
        public void Able_to_create_instance()
        {
        }

        [TestMethod]
        public async Task Able_to_add_user()
        {
            var user = MockUserBuilder.Build();

            await _sut.Save(user);

            var actual = await _sut.GetByEmail(user.Credentials.Email);
            actual.Should().BeEquivalentTo(user);
        }
    }
}
