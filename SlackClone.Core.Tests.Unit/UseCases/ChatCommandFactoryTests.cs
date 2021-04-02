using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClone.Contract.Dtos;
using SlackClone.Contract.Requests;
using SlackClone.Core.Tests.Unit.Fakes;
using SlackClone.Core.UseCases;
using System;
using System.Collections.Generic;

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
        public void Able_to_create_SendMessageToChannelCommand()
        {
            var request = new SendMessageToChannelRequest();

            ICommand<MessageDto> actual = _sut.Create<MessageDto>(request);
            actual.Should().BeOfType(typeof(SendMessageToChannelCommand));
        }

        [TestMethod]
        public void Able_to_create_GetChannelMessagesCommand()
        {
            var request = new GetChannelMessagesRequest();

            ICommand<IEnumerable<MessageDto>> actual = _sut.Create<IEnumerable<MessageDto>>(request);
            actual.Should().BeOfType(typeof(GetChannelMessagesCommand));
        }

        [TestMethod]
        public void Able_to_create_CreateChannelCommand()
        {
            var request = new CreateChannelRequest();

            ICommand<ChannelDto> actual = _sut.Create<ChannelDto>(request);
            actual.Should().BeOfType(typeof(CreateChannelCommand));
        }

        [TestMethod]
        public void Able_to_create_UpdateChannelCommand()
        {
            var request = new UpdateChannelRequest();

            ICommand<ChannelDto> actual = _sut.Create<ChannelDto>(request);
            actual.Should().BeOfType(typeof(UpdateChannelCommand));
        }

        [TestMethod]
        public void Able_to_create_GetSubscribedChannels()
        {
            var request = new GetSubscribedChannelsRequest();

            ICommand<IEnumerable<ChannelDto>> actual = _sut.Create<IEnumerable<ChannelDto>>(request);
            actual.Should().BeOfType(typeof(GetSubscribedChannelsCommand));
        }

        [TestMethod]
        public void Throws_exception_when_trying_to_create_command_from_invalid_request()
        {
            Action action = () => 
                _sut.Create<object>(new object() as IRequest);

            action.Should().Throw<Exception>()
                .WithMessage("Unable to create chat command.");
        }
    }
}
