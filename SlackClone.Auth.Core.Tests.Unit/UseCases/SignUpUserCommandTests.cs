using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClone.Auth.Core.Models;
using SlackClone.Auth.Core.Tests.Unit.Fakes;
using SlackClone.Auth.Core.UseCases;
using SlackClone.Contract.Dtos;
using SlackClone.Contract.Requests;
using SlackClone.Core.Exceptions;
using System;

namespace SlackClone.Auth.Core.Tests.Unit.UseCases
{
    [TestClass]
    [TestCategory("Unit")]
    public class SignUpUserCommandTests
    {
        private SignUpUserCommand _sut;
        private FakeUserRepository _userRepo;

        private SignUpUserRequest _request;

        [TestInitialize]
        public void Initialize()
        {
            _userRepo = new FakeUserRepository();

            _request = new SignUpUserRequest
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "FirstName.LastName@example.com",
                Password = "password"
            };
        }

        [TestMethod]
        public void Able_to_create_instance()
        {
            CreateSut();

            _sut.Should().NotBeNull();
        }

        [TestMethod]
        public void Able_to_sign_up_new_user()
        {
            _userRepo.ThrowsOnGet = new EntityNotFoundException(typeof(User));
            CreateSut();

            UserDto actual = _sut.Execute().Result;
            UserDto expected = MockUserDtoBuilder.Build(
                token: MockTokenDtoBuilder.Build());

            actual.Should().BeEquivalentTo(expected,
                opt => opt.Excluding(obj => obj.Id));

            _userRepo.Saved.FirstName.Should().Be(_request.FirstName);
            _userRepo.Saved.LastName.Should().Be(_request.LastName);
            _userRepo.Saved.Credentials.Email.Should().Be(_request.Email);
        }

        [TestMethod]
        public void Throws_exception_when_user_with_same_email_already_exists()
        {
            _userRepo.Returns = MockUserBuilder.Build();
            CreateSut();

            Action action = ()
                => _sut.Execute().Wait();

            action.Should().Throw<EntityAlreadyExistsException>();
        }

        private void CreateSut()
        {
            _sut = new SignUpUserCommand(
                _request,
                _userRepo,
                new FakeTokenGenerator { Returns = MockTokenDtoBuilder.Build() });
        }
    }
}
