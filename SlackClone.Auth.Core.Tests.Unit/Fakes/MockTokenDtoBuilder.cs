using SlackClone.Contract.Dtos;
using SlackClone.Core.Tests.Unit.Fakes;
using System;

namespace SlackClone.Auth.Core.Tests.Unit.Fakes
{
    public static class MockTokenDtoBuilder
    {
        public static TokenDto Build(
            string value = "Value",
            string type = "Type",
            DateTimeOffset? expiresAt = null)
        {
            return new TokenDto
            {
                Value = value,
                Type = type,
                ExpiresAt = expiresAt ?? DateTimeProvider.Tomorrow
            };
        }
    }
}
