using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClone.Contract.Dtos;
using SlackClone.Contract.Requests;
using SlackClone.Core.Exceptions;
using SlackClone.Core.Tests.Unit.Fakes;
using SlackClone.Core.UseCases;
using System;

namespace SlackClone.Core.Tests.Unit.UseCases
{
    [TestClass]
    [TestCategory("Unit")]
    public class SignInUserCommandTests
    {
        private SignInUserCommand _sut;

        private SignInUserRequest _request;

        [TestInitialize]
        public void Initialize()
        {
            _request = new SignInUserRequest
            {
                Email = "FirstName.LastName@example.com",
            };
        }

        [TestMethod]
        public void Able_to_create_instance()
        {
            CreateSut();

            _sut.Should().NotBeNull();
        }

        [TestMethod]
        public void Able_to_get_user_when_password_is_matching_for_existing_user()
        {
            _request.Password = "password";
            CreateSut();

            UserDto actual = _sut.Execute().Result;

            UserDto expected = MockUserDtoBuilder.Build(
                token: MockTokenDtoBuilder.Build());

            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Throws_exception_when_password_is_not_matching_for_existing_user()
        {
            _request.Password = "wrongpassword";
            CreateSut();

            Action action = ()
                => _sut.Execute().Wait();

            action.Should().Throw<InvalidUserCredentialsException>();
        }

        private void CreateSut()
        {
            _sut = new SignInUserCommand(
                _request,
                new FakeUserRepository { Returns = MockUserBuilder.Build() },
                new FakeTokenGenerator { Returns = MockTokenDtoBuilder.Build() });
        }
    }
}
