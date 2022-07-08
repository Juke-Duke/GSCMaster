using MediatR;

namespace GSCMaster.Core.Commands.Authentication;
public class RegisterCommand : IRequest<bool>
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