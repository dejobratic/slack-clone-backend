﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClone.Auth.Core.Extensions;
using SlackClone.Auth.Core.Models;
using SlackClone.Auth.Core.Tests.Unit.Fakes;
using SlackClone.Contract.Dtos;
using SlackClone.Core.Extensions;

namespace SlackClone.Auth.Core.Tests.Unit.Extensions
{
    [TestClass]
    [TestCategory("Unit")]
    public class UserExtensionsTests
    {
        [TestMethod]
        public void Able_to_map_to_contract_model()
        {
            User user = MockUserBuilder.Build();

            UserDto actual = user.ToContractModel();
            UserDto expected = MockUserDtoBuilder.Build();

            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Able_to_add_token_to_user_dto()
        {
            var user = MockUserDtoBuilder.Build();
            var token = MockTokenDtoBuilder.Build();

            var actual = user.WithToken(token);
            var expected = MockUserDtoBuilder.Build(token: token);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
