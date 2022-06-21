using GSCMasterGuide.Shared.Enums;

namespace GSCMasterGuide.Shared.Responses.Authentication
{
    public record RegisterResponse
    (
        Status Status,
        string? Email = null,
        string? Username = null,
        string? Token = null
    );
}