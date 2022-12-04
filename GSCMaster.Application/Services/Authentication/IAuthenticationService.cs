using GSCMaster.Contracts.Authentication.Requests;
using GSCMaster.Contracts.Authentication.Response;

namespace GSCMaster.Application.Services.Authentication;
public interface IAuthenticationService
{
    Task<AuthenticationResponse> RegisterTrainerAsync(RegisterTrainerRequest request, CancellationToken cancellationToken);

    Task<AuthenticationResponse> LoginTrainerAsync(LoginTrainerRequest request, CancellationToken cancellationToken);
}