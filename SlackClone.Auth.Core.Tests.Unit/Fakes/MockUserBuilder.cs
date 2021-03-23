using SlackClone.Auth.Core.Models;
using SlackClone.Core.Tests.Unit.Fakes;
using System;

namespace SlackClone.Auth.Core.Tests.Unit.Fakes
{
    public static class MockUserBuilder
    {
        public static User Build(
            Guid? id = null,
            string firstName = "FirstName",
            string lastName = "LastName",
            UserCredentials credentials = null)
        {
            return new User(
                id ?? GuidProvider.UserId,
                firstName,
                lastName,
                credentials ?? MockUserCredentialsBuilder.Build());
        }
    }
}
