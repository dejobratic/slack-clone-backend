namespace SlackClone.Contract.Requests
{
    public class SignInUserRequest :
        IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
