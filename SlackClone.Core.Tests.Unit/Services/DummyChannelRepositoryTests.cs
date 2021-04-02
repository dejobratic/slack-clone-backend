using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClone.Core.Models;
using SlackClone.Core.Services;
using System;
using System.Threading.Tasks;

namespace SlackClone.Core.Tests.Unit.Services
{
    [TestClass]
    [TestCategory("Unit")]
    public class DummyChannelRepositoryTests
    {
        private DummyChannelRepository _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new DummyChannelRepository();
        }

        [TestMethod]
        public void Able_to_create_instance()
        {
        }

        [TestMethod]
        public async Task Able_to_get_all_channels()
        {
            var firstChannel = new Channel
            {
                Id = Guid.NewGuid(),
                Name = "Name1",
                CreatedAt = DateTime.Now,
                CreatorId = Guid.NewGuid()
            };

            var secondChannel = new Channel
            {
                Id = Guid.NewGuid(),
                Name = "Name2",
                CreatedAt = DateTime.Now,
                CreatorId = Guid.NewGuid()
            };

            await _sut.Save(firstChannel);
            await _sut.Save(secondChannel);

            var actual = await _sut.Get();

            actual.Should().HaveCount(2);
            actual.Should().Contain(firstChannel);
            actual.Should().Contain(secondChannel);
        }

        [TestMethod]
        public async Task Able_to_add_channel()
        {
            var channel = new Channel
            {
                Id = Guid.NewGuid(),
                Name = "Name",
                CreatedAt = DateTime.Now,
                CreatorId = Guid.NewGuid()
            };

            await _sut.Save(channel);
            var actual = await _sut.Get(channel.Id);

            actual.Should().BeEquivalentTo(channel);
        }

        [TestMethod]
        public async Task Throws_exception_when_trying_to_add_channel_with_same_name()
        {
            var firstChannel = new Channel
            {
                Id = Guid.NewGuid(),
                Name = "Name",
                CreatedAt = DateTime.Now,
                CreatorId = Guid.NewGuid()
            };

            var secondChannel = new Channel
            {
                Id = Guid.NewGuid(),
                Name = "Name",
                CreatedAt = DateTime.Now,
                CreatorId = Guid.NewGuid()
            };

            await _sut.Save(firstChannel);

            Func<Task> action = () => _sut.Save(secondChannel);

            action.Should().Throw<Exception>()
                .WithMessage("Channel with name Name already exists.");
        }

        [TestMethod]
        public async Task Able_to_update_channel()
        {
            var channel = new Channel
            {
                Id = Guid.NewGuid(),
                Name = "Name",
                CreatedAt = DateTime.Now,
                CreatorId = Guid.NewGuid()
            };

            await _sut.Save(channel);

            channel.Name = "New Name";
            await _sut.Save(channel);

            var channels = await _sut.Get();
            channels.Should().HaveCount(1);
            channels.Should().Contain(channel);
        }
    }
}
