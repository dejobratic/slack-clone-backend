using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClone.Core.Models;
using SlackClone.Core.Services;
using System;

namespace SlackClone.Core.Tests.Unit.Services
{
    [TestClass]
    [TestCategory("Unit")]
    public class DateRangeProviderTests
    {
        private DateRangeProvider _sut;

        private readonly DateRange _expected = 
            new DateRange(DateTime.UtcNow, DateTime.UtcNow.AddDays(1));

        [TestInitialize]
        public void Initialize()
        {
            _sut = new DateRangeProvider(_expected);
        }

        [TestMethod]
        public void Able_to_create_instance()
        {
        }

        [TestMethod]
        public void Able_to_provide_date_range()
        {
            DateRange actual = _sut.Provide();

            actual.Should().Be(_expected);
        }
    }
}
