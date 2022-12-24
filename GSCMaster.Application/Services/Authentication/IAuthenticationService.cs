using GSCMaster.Application.Features.Authentication;
using GSCMaster.Core.Common.Primitives;

namespace GSCMaster.Application.Services.Authentication;
public interface IAuthenticationService
{
    Task<ErrorProne<AuthenticationResponse>> RegisterTrainerAsync(RegisterTrainerCommand request, CancellationToken cancellationToken);

    Task<ErrorProne<AuthenticationResponse>> LoginTrainerAsync(LoginTrainerCommand request, CancellationToken cancellationToken);
}