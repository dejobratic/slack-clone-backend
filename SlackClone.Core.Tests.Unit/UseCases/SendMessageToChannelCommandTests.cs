using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClone.Contract.Dtos;
using SlackClone.Contract.Requests;
using SlackClone.Core.Tests.Unit.Fakes;
using SlackClone.Core.UseCases;
using System;
using System.Threading.Tasks;

namespace SlackClone.Core.Tests.Unit.UseCases
{
    [TestClass]
    [TestCategory("Unit")]
    public class SendMessageToChannelCommandTests
    {
        private SendMessageToChannelCommand _sut;

        private readonly string _expectedText = "Some text!";
        private readonly Guid _expectedChannelId = Guid.NewGuid();
        private readonly Guid _expectedCreatorId = Guid.NewGuid();
        private readonly DateTimeOffset _expectedCreatedAt = DateTimeOffset.UtcNow;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new SendMessageToChannelCommand(
                new SendMessageToChannelRequest
                {
                    Text = _expectedText,
                    CreatorId = _expectedCreatorId,
                    ChannelId = _expectedChannelId
                },
                new FakeTimestampProvider { Returns = _expectedCreatedAt },
                new FakeMessageRepository());
        }

        [TestMethod]
        public void Able_to_create_instance()
        {
        }

        [TestMethod]
        public async Task Able_to_execute_command()
        {
            MessageDto actual = await _sut.Execute();

            var expected = new MessageDto
            {
                Id = Guid.NewGuid(),
                Text = _expectedText,
                ChannelId = _expectedChannelId,
                Creator = new UserDto
                {
                    Name = "Dejan Bratic",
                    ImageUrl = "https://www.kindpng.com/picc/m/78-786207_user-avatar-png-user-avatar-icon-png-transparent.png"
                },
                CreatedAt = _expectedCreatedAt
            };

            actual.Id.Should().NotBeEmpty();
            actual.Should().BeEquivalentTo(expected, opt =>
                opt.Excluding(ctx => ctx.Id)
            );
        }
    }
}
