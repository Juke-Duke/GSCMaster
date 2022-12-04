using MongoDB.Bson;

namespace GSCMaster.Contracts.Authentication.Response;
public record AuthenticationResponse
(
    ObjectId Id,
    string Username,
    string Email,
    string Token
);