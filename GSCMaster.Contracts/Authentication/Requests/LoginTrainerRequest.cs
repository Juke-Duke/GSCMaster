namespace GSCMaster.Contracts.Authentication.Requests;
public record LoginTrainerRequest
(
    string Username,
    string Email,
    string Password
);