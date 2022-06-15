namespace GSCMasterGuide.Identity.Requests
{
    public record AuthenticationResponse
    (
        Guid Id,
        string Email,
        string Username,
        string Password,
        string Token
    );
}
