using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClone.Contract.Dtos;
using SlackClone.Core.Extensions;
using SlackClone.Core.Models;
using System;
using System.Collections.Generic;

namespace SlackClone.Core.Tests.Unit.Extensions
{
    [TestClass]
    [TestCategory("Unit")]
    public class ChannelExtensionsTests
    {
        [TestMethod]
        public void Able_to_map_to_contract_model()
        {
            var expectedId = Guid.NewGuid();
            var expectedName = "Channel";
            var expectedDesctiption = "Description";
            var expectedCreatorId = Guid.NewGuid();

            var channel = new Channel
            {
                Id = expectedId,
                Name = expectedName,
                Description = expectedDesctiption,
                CreatedAt = DateTime.Now,
                CreatorId = expectedCreatorId,
                SubscriberIds = new List<Guid>
                {
                    expectedCreatorId
                }
            };

            var actual = channel.ToContractModel();
            var expected = new ChannelDto
            {
                Id = expectedId,
                Name = expectedName,
                Description = expectedDesctiption,
                CreatorId = expectedCreatorId,
                SubscriberIds = new Guid[]
                {
                    expectedCreatorId
                }
            };

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
