using System.ComponentModel.DataAnnotations;

namespace GSCMasterGuide.Shared.Requests.Authentication
{
    public record RegisterRequest
    (
        [Required(ErrorMessage = "Email is required")] string Email,
        [Required(ErrorMessage = "Username is required")] string Username,
        [Required(ErrorMessage = "Password is required")] string Password,
        [Required(ErrorMessage = "Confirm password is required")] string ConfirmPassword
    );
}