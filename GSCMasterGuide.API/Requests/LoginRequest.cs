namespace GSCMasterGuide.Identity.Requests
{
    public record LoginRequest
    (
        string Username,
        string Password
    );
}