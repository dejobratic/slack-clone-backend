using SlackClone.Contract.Dtos;
using SlackClone.Contract.Requests;
using SlackClone.Core.Exceptions;
using SlackClone.Core.Extensions;
using SlackClone.Core.Models;
using SlackClone.Core.Services;
using System.Threading.Tasks;

namespace SlackClone.Core.UseCases
{
    public class SignUpUserCommand :
        ICommand<UserDto>
    {
        private readonly SignUpUserRequest _request;
        private readonly IUserRepository _userRepo;
        private readonly ITokenGenerator _tokenGenerator;

        public SignUpUserCommand(
            SignUpUserRequest request,
            IUserRepository userRepo,
            ITokenGenerator tokenGenerator)
        {
            _request = request;
            _userRepo = userRepo;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<UserDto> Execute()
        {
            await ThrowIfUserAlreadyExists();

            User user = CreateUser();
            await _userRepo.Save(user);

            var token = _tokenGenerator.Generate(user);
            return user.ToContractModel().WithToken(token);
        }

        private async Task ThrowIfUserAlreadyExists()
        {
            try
            {
                await _userRepo.GetByEmail(_request.Email);
                throw new EntityAlreadyExistsException(typeof(User));
            }
            catch (EntityNotFoundException) { }
        }

        private User CreateUser()
        {
            return new User(
                _request.FirstName,
                _request.LastName,
                CreateCredentials());
        }

        private UserCredentials CreateCredentials()
        {
            return new UserCredentials(
                _request.Email,
                _request.Password);
        }
    }
}
