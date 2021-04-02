using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlackClone.Auth.Core.UseCases;
using SlackClone.Contract.Dtos;
using SlackClone.Contract.Requests;
using SlackClone.Core.UseCases;
using System.Threading.Tasks;

namespace SlackClone.Web.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class AuthController : 
        ControllerBase
    {
        private readonly IAuthCommandFactory _commandFactory;

        public AuthController(
            IAuthCommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        [HttpPost]
        [Route("api/users")]
        public async Task<IActionResult> SignUpUser(
            [FromBody] SignUpUserRequest request)
        {
            ICommand<UserDto> command = _commandFactory.Create<UserDto>(request);
            return Ok(await command.Execute());
        }

        [HttpGet]
        [Route("api/users")]
        public async Task<IActionResult> SignInUser(
            [FromHeader] string email,
            [FromHeader] string password)
        {
            var request = new SignInUserRequest
            {
                Email = email,
                Password = password
            };

            ICommand<UserDto> command = _commandFactory.Create<UserDto>(request);
            return Ok(await command.Execute());
        }
    }
}
