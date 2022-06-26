using System.ComponentModel.DataAnnotations;

namespace GSCMasterGuide.Shared.Requests.Authentication;
public class RegisterRequest
{
    [Required(ErrorMessage = "Email is required", AllowEmptyStrings = false)]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Username is required", AllowEmptyStrings = false)]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "Password is required", AllowEmptyStrings = false)]
    [MinLength(6)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Confirm password is required", AllowEmptyStrings = false)]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = null!;
}