using SlackClone.Core.Exceptions;
using SlackClone.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlackClone.Core.Services
{
    public class DummyUserRepository :
        IUserRepository
    {
        private readonly Dictionary<Guid, User> _userSet;

        public DummyUserRepository()
        {
            _userSet = new Dictionary<Guid, User>();
        }

        public Task<User> GetByEmail(string email)
        {
            User existingUser = _userSet.Values
                .Where(u => u.Credentials.Email == email)
                .SingleOrDefault();

            if (existingUser is null)
                throw new EntityNotFoundException(typeof(User));

            return Task.FromResult(existingUser);
        }

        public Task Save(User user)
        {
            if (_userSet.ContainsKey(user.Id))
                _userSet[user.Id] = user;
            else
                _userSet.Add(user.Id, user);

            return Task.CompletedTask;
        }
    }
}
