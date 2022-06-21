using GSCMasterGuide.Shared.Responses.Authentication;
using MediatR;

namespace GSCMasterGuide.API.Commands.Authentication
{
    public class RegisterCommand : IRequest<RegisterResponse>
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public RegisterCommand(string email, string username, string password, string confirmPassword)
        {
            Email = email.Trim();
            Username = username;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
}
