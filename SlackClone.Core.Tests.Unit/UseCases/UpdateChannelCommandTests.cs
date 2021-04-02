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
    public class UpdateChannelCommandTests
    {
        private UpdateChannelCommand _sut;

        private readonly Guid _expectedId = Guid.NewGuid();
        private readonly string _expectedName = "Some name!";
        private readonly string _expectedDescription = "Some description!";
        private readonly Guid _expectedCreatorId = Guid.NewGuid();

        [TestInitialize]
        public void Initialize()
        {
            _sut = new UpdateChannelCommand(
                new UpdateChannelRequest
                {
                    Id = _expectedId,
                    Name = _expectedName,
                    Description = _expectedDescription,
                },
                new FakeChannelRepository
                {
                    Returns = new[]
                    {
                        new Channel
                        {
                            Id = _expectedId,
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
            ChannelDto actual = await _sut.Execute();

            var expected = new ChannelDto
            {
                Id = _expectedId,
                Name = _expectedName,
                Description = _expectedDescription,
                SubscriberIds = new Guid[]
                {
                    _expectedCreatorId
                }
            };

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
