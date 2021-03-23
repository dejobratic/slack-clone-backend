using SlackClone.Contract.Dtos;
using SlackClone.Core.Models;

namespace SlackClone.Core.Extensions
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
