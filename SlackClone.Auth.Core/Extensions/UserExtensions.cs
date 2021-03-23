using SlackClone.Auth.Core.Models;
using SlackClone.Contract.Dtos;

namespace SlackClone.Auth.Core.Extensions
{
    public static class UserExtensions
    {
        public static UserDto ToContractModel(
            this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Credentials.Email
            };
        }

        public static UserDto WithToken(
            this UserDto user,
            TokenDto token)
        {
            user.Token = token;
            return user;
        }
    }
}
