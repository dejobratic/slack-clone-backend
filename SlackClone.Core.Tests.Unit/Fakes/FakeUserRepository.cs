﻿using SlackClone.Core.Models;
using SlackClone.Core.Services;
using System;
using System.Threading.Tasks;

namespace SlackClone.Core.Tests.Unit.Fakes
{
    public class FakeUserRepository :
        IUserRepository
    {
        public User Returns { get; set; }
        public Exception ThrowsOnGet { get; set; }
        public User Saved { get; private set; }

        public Task<User> GetByEmail(string email)
        {
            if (ThrowsOnGet is { })
                throw ThrowsOnGet;

            return Task.FromResult(Returns);
        }

        public Task Save(User user)
        {
            Saved = user;
            return Task.CompletedTask;
        }
    }
}
