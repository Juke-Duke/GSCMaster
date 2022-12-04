namespace GSCMaster.Contracts.Authentication.Requests;
public record RegisterTrainerRequest
(
    string Username,
    string Email,
    string Password,
    string ConfirmPassword
);