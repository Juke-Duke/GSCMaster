using System.ComponentModel.DataAnnotations;

namespace GSCMaster.Shared.Requests.Authentication;
public class RegisterRequest
{
    [Required(ErrorMessage = "Email is required", AllowEmptyStrings = false)]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Username is required", AllowEmptyStrings = false)]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "Password is required", AllowEmptyStrings = false)]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Confirm password is required", AllowEmptyStrings = false)]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = null!;
}