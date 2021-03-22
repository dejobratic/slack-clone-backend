using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClone.Contract.Dtos;
using SlackClone.Contract.Requests;
using SlackClone.Core.Tests.Unit.Fakes;
using SlackClone.Core.UseCases;
using System;

namespace SlackClone.Core.Tests.Unit.UseCases
{
    [TestClass]
    [TestCategory("Unit")]
    public class ChatCommandFactoryTests
    {
        private ChatCommandFactory _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new ChatCommandFactory(
                new FakeTimestampProvider(),
                new FakeMessageRepository(),
                new FakeChannelRepository());
        }

        [TestMethod]
        public void Able_to_create_instance()
        {
        }

        [TestMethod]
        public void Able_to_create_SendMessageToGroupChatCommand()
        {
            var request = new SendMessageToGroupChatRequest();

            ICommand<MessageDto> actual = _sut.Create<MessageDto>(request);
            actual.Should().BeOfType(typeof(SendMessageToGroupChatCommand));
        }

        [TestMethod]
        public void Able_to_create_CreateChannelCommand()
        {
            var request = new CreateChannelRequest();

            ICommand<ChannelDto> actual = _sut.Create<ChannelDto>(request);
            actual.Should().BeOfType(typeof(CreateChannelCommand));
        }

        [TestMethod]
        public void Throws_exception_when_trying_to_create_command_with_return_type_from_invalid_request()
        {
            Action action = () => 
                _sut.Create<object>(new object() as IRequest);

            action.Should().Throw<Exception>()
                .WithMessage("Unable to create chat command.");
        }

        [TestMethod]
        public void Throw_exception_when_trying_to_create_command_without_return_parameters_with_invalid_request()
        {
            Action action = () =>
                _sut.Create(new object() as IRequest);

            action.Should().Throw<NotImplementedException>();
        }
    }
}
