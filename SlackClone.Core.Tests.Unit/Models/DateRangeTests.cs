using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClone.Core.Models;
using System;

namespace SlackClone.Core.Tests.Unit.Models
{
    [TestClass]
    public class DateRangeTests
    {
        [TestMethod]
        public void Able_to_create_instance()
        {
            var expectedFrom = DateTimeOffset.UtcNow;
            var expectedTo = DateTimeOffset.UtcNow.AddDays(1);

            var actual = new DateRange(
                expectedFrom,
                expectedTo);

            actual.From.Should().Be(expectedFrom);
            actual.To.Should().Be(expectedTo);
        }
    }
}
