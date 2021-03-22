using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClone.Core.Services;
using System;

namespace SlackClone.Core.Tests.Unit.Services
{
    [TestClass]
    [TestCategory("Unit")]
    public class TimestampProviderTests
    {
        private TimestampProvider _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new TimestampProvider();
        }

        [TestMethod]
        public void Able_to_create_instance()
        {
        }

        [TestMethod]
        public void Able_to_provide_timestamp()
        {
            DateTimeOffset actual = _sut.Provide();

            var expected = DateTimeOffset.UtcNow;

            (actual - expected).TotalMilliseconds.Should().BeInRange(-100, 100);
        }
    }
}
