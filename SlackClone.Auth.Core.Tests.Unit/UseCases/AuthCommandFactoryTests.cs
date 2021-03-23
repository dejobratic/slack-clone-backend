using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClone.Auth.Core.Tests.Unit.Fakes;
using SlackClone.Auth.Core.UseCases;
using SlackClone.Contract.Dtos;
using SlackClone.Contract.Requests;
using SlackClone.Core.UseCases;
using System;

namespace SlackClone.Auth.Core.Tests.Unit.UseCases
{
    [TestClass]
    [TestCategory("Unit")]
    public class AuthCommandFactoryTests
    {
        private AuthCommandFactory _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new AuthCommandFactory(
                new FakeTokenGenerator(),
                new FakeUserRepository());
        }

        [TestMethod]
        public void Able_to_create_instance()
        {
        }

        [TestMethod]
        public void Able_to_create_SignInUserCommand()
        {
            var request = new SignInUserRequest();

            ICommand<UserDto> actual = _sut.Create<UserDto>(request);
            actual.Should().BeOfType(typeof(SignInUserCommand));
        }

        [TestMethod]
        public void Able_to_create_SignUpUserCommand()
        {
            var request = new SignUpUserRequest();

            ICommand<UserDto> actual = _sut.Create<UserDto>(request);
            actual.Should().BeOfType(typeof(SignUpUserCommand));
        }

        [TestMethod]
        public void Throws_exception_when_trying_to_create_command_from_invalid_request()
        {
            Action action = () =>
                _sut.Create<object>(new object() as IRequest);

            action.Should().Throw<Exception>()
                .WithMessage("Unable to create auth command.");
        }
    }
}
