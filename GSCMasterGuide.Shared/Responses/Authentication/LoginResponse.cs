using GSCMasterGuide.Shared.Enums;

namespace GSCMasterGuide.Shared.Responses.Authentication
{
    public record LoginResponse
    (
        Status Status,
        string? Username = null,
        string? Token = null,
        DateTime? Expires = null
    );
}