using System;

namespace SlackClone.Auth.Core.Exceptions
{
    public class InvalidUserCredentialsException :
        Exception
    {
        public InvalidUserCredentialsException()
            : base($"User credentials are not valid.")
        {
        }
    }
}
