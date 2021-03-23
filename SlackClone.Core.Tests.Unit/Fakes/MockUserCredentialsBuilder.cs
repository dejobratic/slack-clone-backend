using SlackClone.Core.Models;

namespace SlackClone.Core.Tests.Unit.Fakes
{
    public static class MockUserCredentialsBuilder
    {
        public static UserCredentials Build(
            string email = "FirstName.LastName@example.com",
            string password = "password")
        {
            return new UserCredentials(
                email,
                password);
        }
    }
}
