using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClone.Contract.Dtos;
using SlackClone.Core.Extensions;
using SlackClone.Core.Models;
using System;

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

            var channel = new Channel
            {
                Id = expectedId,
                Name = expectedName,
                CreatedAt = DateTime.Now,
                CreatorId = Guid.NewGuid()
            };

            var actual = channel.ToContractModel();
            var expected = new ChannelDto
            {
                Id = expectedId,
                Name = expectedName
            };

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
