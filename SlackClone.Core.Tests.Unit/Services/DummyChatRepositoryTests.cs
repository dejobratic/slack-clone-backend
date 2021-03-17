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
    public class DummyChatRepositoryTests
    {
        private DummyChatRepository _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new DummyChatRepository();
        }

        [TestMethod]
        public void Able_to_create_instance()
        {
        }

        [TestMethod]
        public async Task Able_to_add_message()
        {
            var message = new Message
            {
                Id = Guid.NewGuid(),
                Text = "Text",
                CreatorId = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                ChannelId = Guid.NewGuid()
            };

            await _sut.Save(message);

            var specification = new MessageSpecification
            {
                ChannelId = message.ChannelId,
                PageNumber = 1,
                PageSize = 1
            };
            var messages = await _sut.GetBy(specification);

            messages.Should().HaveCount(1);
            messages.Should().Contain(message);
        }

        [TestMethod]
        public async Task Able_to_add_messages_to_multiple_chats()
        {
            var message1 = new Message
            {
                Id = Guid.NewGuid(),
                Text = "Text",
                CreatorId = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                ChannelId = Guid.NewGuid()
            };

            var message2 = new Message
            {
                Id = Guid.NewGuid(),
                Text = "Text",
                CreatorId = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                ChannelId = Guid.NewGuid()
            };

            await _sut.Save(message1);
            await _sut.Save(message2);

            var specification1 = new MessageSpecification
            {
                ChannelId = message1.ChannelId,
                PageNumber = 1,
                PageSize = 1
            };

            var specification2 = new MessageSpecification
            {
                ChannelId = message2.ChannelId,
                PageNumber = 1,
                PageSize = 1
            };

            var messages1 = await _sut.GetBy(specification1);
            var messages2 = await _sut.GetBy(specification2);

            messages1.Should().HaveCount(1);
            messages1.Should().Contain(message1);

            messages2.Should().HaveCount(1);
            messages2.Should().Contain(message2);
        }

        [TestMethod]
        public async Task Able_to_update_message_in_existing_chat()
        {
            var message = new Message
            {
                Id = Guid.NewGuid(),
                Text = "Text",
                CreatorId = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                ChannelId = Guid.NewGuid()
            };

            await _sut.Save(message);

            message.Text = "New Text";
            await _sut.Save(message);

            var specification = new MessageSpecification
            {
                ChannelId = message.ChannelId,
                PageNumber = 1,
                PageSize = 1
            };
            var messages = await _sut.GetBy(specification);

            messages.Should().HaveCount(1);
            messages.Should().Contain(message);
        }

        [TestMethod]
        public async Task Able_to_get_messages_by_specification()
        {
            Message message = null;
            Guid channelId = Guid.NewGuid();

            for(int i = 0; i < 5; i++)
            {
                message = new Message
                {
                    Id = Guid.NewGuid(),
                    Text = "Text",
                    CreatorId = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    ChannelId = channelId
                };

                await _sut.Save(message);
            }

            var specification = new MessageSpecification
            {
                ChannelId = channelId,
                PageNumber = 5,
                PageSize = 1
            };

            var messages = await _sut.GetBy(specification);

            messages.Should().HaveCount(1);
            messages.Should().Contain(message);
        }

        [TestMethod]
        public async Task Returns_empty_array_when_no_channel_is_found_by_specification()
        {
            var specification = new MessageSpecification
            {
                ChannelId = Guid.Parse("a0f9a2b7-a74a-41c4-8a58-ca495b45ce4d")
            };

            var messages = await _sut.GetBy(specification);

            messages.Should().BeEmpty();
        }
    }
}
