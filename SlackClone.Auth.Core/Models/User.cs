using System;

namespace SlackClone.Auth.Core.Models
{
    public class User
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public UserCredentials Credentials { get; }

        public User(
            string firstName,
            string lastName,
            UserCredentials credentials)
            : this(Guid.NewGuid(), firstName, lastName, credentials)
        {
        }

        public User(
            Guid id,
            string firstName,
            string lastName,
            UserCredentials credentials)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Credentials = credentials;
        }
    }
}
