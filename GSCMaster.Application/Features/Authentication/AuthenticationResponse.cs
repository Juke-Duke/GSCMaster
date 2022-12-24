using MongoDB.Bson;

namespace GSCMaster.Application.Features.Authentication;
public record AuthenticationResponse
(
    ObjectId Id,
    string Username,
    string Email,
    string Token
);