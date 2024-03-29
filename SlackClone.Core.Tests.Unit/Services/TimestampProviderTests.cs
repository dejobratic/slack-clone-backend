﻿using FluentAssertions;
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

        private readonly DateTimeOffset _expected = DateTimeOffset.UtcNow;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new TimestampProvider(_expected);
        }

        [TestMethod]
        public void Able_to_create_instance()
        {
        }

        [TestMethod]
        public void Able_to_provide_timestamp()
        {
            DateTimeOffset actual = _sut.Provide();

            actual.Should().Be(_expected);
        }
    }
}
