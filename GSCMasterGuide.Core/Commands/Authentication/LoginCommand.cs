using GSCMasterGuide.Shared.Responses.Authentication;
using MediatR;

namespace GSCMasterGuide.Domain.Commands.Authentication
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
