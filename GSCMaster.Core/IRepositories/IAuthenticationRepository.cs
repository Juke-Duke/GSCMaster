using GSCMaster.Shared.Requests.Authentication;

namespace GSCMaster.Core.IRepositories;
public interface IAuthenticationRepository
{
    Task<bool> Register(RegisterRequest request, CancellationToken cancellationToken);

    // Task Login(LoginRequest request, CancellationToken cancellationToken);
}