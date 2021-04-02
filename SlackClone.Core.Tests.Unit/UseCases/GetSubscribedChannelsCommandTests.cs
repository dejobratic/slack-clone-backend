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
    public class GetSubscribedChannelsCommandTests
    {
        private GetSubscribedChannelsCommand _sut;

        private readonly string _expectedName = "Some name!";
        private readonly string _expectedDescription = "Some description!";
        private readonly Guid _expectedCreatorId = Guid.NewGuid();
        private readonly DateTimeOffset _expectedCreatedAt = DateTimeOffset.UtcNow;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new GetSubscribedChannelsCommand(
                new GetSubscribedChannelsRequest(),
                new FakeChannelRepository
                {
                    Returns = new[]
                    {
                        new Channel
                        {
                            Id = Guid.NewGuid(),
                            Name = _expectedName,
                            Description = _expectedDescription,
                            CreatorId = _expectedCreatorId,
                            CreatedAt = _expectedCreatedAt,
                            SubscriberIds = new List<Guid>
                            {
                                _expectedCreatorId
                            }
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
            IEnumerable<ChannelDto> actual = await _sut.Execute();

            ChannelDto[] expected =
            {
                new ChannelDto
                {
                    Id = Guid.NewGuid(),
                    Name = _expectedName,
                    Description = _expectedDescription,
                    CreatorId = _expectedCreatorId,
                    SubscriberIds = new Guid[]
                    {
                        _expectedCreatorId
                    }
                }
            };

            actual.Should().BeEquivalentTo(expected, opt =>
                opt.Excluding(ctx => ctx.Id));
        }
    }
}
