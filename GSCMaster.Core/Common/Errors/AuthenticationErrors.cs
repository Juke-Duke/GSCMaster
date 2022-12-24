using GSCMaster.Core.Common.Primitives;
using GSCMaster.Core.TrainerAggregate;

namespace GSCMaster.Core.Common.Errors;

public static class AuthenticationErrors
{
    public static Error EmailAlreadyExists = new(
        code: $"Register - {nameof(EmailAlreadyExists)}",
        message: "Email is already in use.");

    public static Error UnconfirmedPassword = new(
        code: $"Register - {nameof(UnconfirmedPassword)}",
        message: "Password and confirmation password do not match.");

    public static Error InvalidLogin = new(
        code: $"Login - {nameof(InvalidLogin)}",
        message: "Invalid login credentials.");
}