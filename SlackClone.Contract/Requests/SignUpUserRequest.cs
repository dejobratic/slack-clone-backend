namespace SlackClone.Contract.Requests
{
    public class SignUpUserRequest :
        IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
