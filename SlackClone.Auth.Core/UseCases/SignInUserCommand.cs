using SlackClone.Auth.Core.Exceptions;
using SlackClone.Auth.Core.Extensions;
using SlackClone.Auth.Core.Models;
using SlackClone.Auth.Core.Services;
using SlackClone.Contract.Dtos;
using SlackClone.Contract.Requests;
using SlackClone.Core.Extensions;
using SlackClone.Core.UseCases;
using System.Threading.Tasks;

namespace SlackClone.Auth.Core.UseCases
{
    public class SignInUserCommand :
        ICommand<UserDto>
    {
        private readonly SignInUserRequest _request;
        private readonly IUserRepository _userRepo;
        private readonly ITokenGenerator _tokenGenerator;

        public SignInUserCommand(
            SignInUserRequest request,
            IUserRepository userRepo,
            ITokenGenerator tokenGenerator)
        {
            _request = request;
            _userRepo = userRepo;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<UserDto> Execute()
        {
            User user = await _userRepo.GetByEmail(_request.Email);

            if (user.Credentials.IsMatchingPassword(_request.Password))
            {
                var token = _tokenGenerator.Generate(user);
                return user.ToContractModel().WithToken(token);
            }

            throw new InvalidUserCredentialsException();
        }
    }
}
