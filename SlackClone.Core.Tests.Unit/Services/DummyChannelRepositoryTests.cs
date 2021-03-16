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
            var channels = await _sut.Get();

            channels.Should().HaveCount(1);
            channels.Should().Contain(channel);
        }

        [TestMethod]
        public async Task Throws_exception_when_trying_to_create_channel_with_same_name()
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
