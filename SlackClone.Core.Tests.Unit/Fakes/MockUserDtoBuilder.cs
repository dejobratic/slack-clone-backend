﻿using SlackClone.Contract.Dtos;
using System;

namespace SlackClone.Core.Tests.Unit.Fakes
{
    public static class MockUserDtoBuilder
    {
        public static UserDto Build(
            Guid? id = null,
            string firstName = "FirstName",
            string lastName = "LastName",
            string email = "FirstName.LastName@example.com",
            TokenDto token = null)
        {
            return new UserDto
            {
                Id = id ?? GuidProvider.UserId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Token = token
            };
        }
    }
}
