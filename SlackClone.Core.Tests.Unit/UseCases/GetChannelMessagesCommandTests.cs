using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClone.Contract.Dtos;
using SlackClone.Contract.Requests;
using SlackClone.Core.Models;
using SlackClone.Core.Tests.Unit.Fakes;
using SlackClone.Core.UseCases;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlackClone.Core.Tests.Unit.UseCases
{
    [TestClass]
    [TestCategory("Unit")]
    public class GetChannelMessagesCommandTests
    {
        private GetChannelMessagesCommand _sut;

        private readonly string _expectedText = "Some text!";
        private readonly Guid _expectedChannelId = Guid.NewGuid();
        private readonly DateTimeOffset _expectedCreatedAt = DateTimeOffset.UtcNow;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new GetChannelMessagesCommand(
                new GetChannelMessagesRequest
                {
                    PageSize = 1,
                    PageNumber = 1,
                    ChannelId = _expectedChannelId
                },
                new FakeMessageRepository
                {
                    Returns = new []
                    {
                        new Message
                        {
                            Id = Guid.NewGuid(),
                            Text = _expectedText,
                            ChannelId = _expectedChannelId,
                            CreatorId = Guid.NewGuid(),
                            CreatedAt = _expectedCreatedAt
                        }
                    }
                });
        }

        [TestMethod]
        public void Able_to_create_instance()
        {
        }

        [TestMethod]
        public async Task Able_to_execute_command()
        {
            IEnumerable<MessageDto> actual = await _sut.Execute();

            MessageDto[] expected =
            {
                new MessageDto
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
                }
            };

            actual.Should().BeEquivalentTo(expected, opt =>
                opt.Excluding(ctx => ctx.Id));
        }
    }
}
