using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClone.Auth.Core.Models;
using SlackClone.Auth.Core.Services;
using SlackClone.Auth.Core.Settings;
using SlackClone.Auth.Core.Tests.Unit.Fakes;
using SlackClone.Contract.Dtos;
using SlackClone.Core.Models;
using SlackClone.Core.Tests.Unit.Fakes;
using System;

namespace SlackClone.Auth.Core.Tests.Unit.Services
{
    [TestClass]
    [TestCategory("Unit")]
    public class JWTGeneratorTests
    {
        private JWTGenerator _sut;

        [TestInitialize]
        public void Initialize()
        {
            CreateSut();
        }

        [TestMethod]
        public void Able_to_create_instance()
        {
        }

        [TestMethod]
        public void Able_to_generate_jwt_token()
        {
            User user = MockUserBuilder.Build();

            TokenDto actual = _sut.Generate(user);
            TokenDto expected = new TokenDto
            {
                Value = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiI3ODJiNjJmYS1kMjZlLTQ2OWQtOGUxYy1iZWQ3NjY4OWM3MmIiLCJuYmYiOjE2MDk0NTU2MDAsImV4cCI6MTYwOTU0MjAwMCwiaWF0IjoxNjA5NDU1NjAwfQ.RbAaLK6SMERAJA8VEO9D4G0hLcSOtnMQoxUvF4h0rxo",
                Type = "Bearer",
                ExpiresAt = DateTimeOffset.Parse("2021-01-02 00:00:00")
            };

            actual.Should().BeEquivalentTo(expected);
        }

        private void CreateSut()
        {
            _sut = new JWTGenerator(
                new JWTSettings
                {
                    Secret = "thirty-two-character-long-string"
                },
                new FakeDateRangeProvider
                {
                    Returns = new DateRange(
                        DateTimeOffset.Parse("2021-01-01 00:00:00"),
                        DateTimeOffset.Parse("2021-01-02 00:00:00"))
                });
        }
    }
}
