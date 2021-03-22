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
    public class CreateChannelCommandTests
    {
        private CreateChannelCommand _sut;

        private readonly string _expectedName = "Some name!";
        private readonly string _expectedDescription = "Some description!";
        private readonly Guid _expectedCreatorId = Guid.NewGuid();
        private readonly DateTimeOffset _expectedCreatedAt = DateTimeOffset.UtcNow;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new CreateChannelCommand(
                new CreateChannelRequest
                {
                    Name = _expectedName,
                    Description = _expectedDescription,
                    CreatorId = _expectedCreatorId,
                },
                new FakeTimestampProvider { Returns = _expectedCreatedAt },
                new FakeChannelRepository());
        }

        [TestMethod]
        public void Able_to_create_instance()
        {
        }

        [TestMethod]
        public async Task Able_to_execute_command()
        {
            ChannelDto actual = await _sut.Execute();

            var expected = new ChannelDto
            {
                Id = Guid.NewGuid(),
                Name = _expectedName,
                Description = _expectedDescription
            };

            actual.Id.Should().NotBeEmpty();
            actual.Should().BeEquivalentTo(expected, opt =>
                opt.Excluding(ctx => ctx.Id)
            );
        }
    }
}
