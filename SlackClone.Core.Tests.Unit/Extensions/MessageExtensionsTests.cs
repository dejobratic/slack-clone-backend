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
    public class MessageExtensionsTests
    {
        [TestMethod]
        public void Able_to_map_to_contract_model()
        {
            var expectedId = Guid.NewGuid();
            var expectedText = "Text";
            var expectedCreatedAt = DateTime.Now;

            var message = new Message
            {
                Id = expectedId,
                Text = expectedText,
                CreatedAt = expectedCreatedAt,
                CreatorId = Guid.NewGuid()
            };

            var actual = message.ToContractModel();
            var expected = new MessageDto
            {
                Id = expectedId,
                Text = expectedText,
                CreatorId = message.CreatorId,
                CreatedAt = expectedCreatedAt,
            };

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
