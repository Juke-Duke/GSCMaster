using GSCMasterGuide.Shared.Requests.Authentication;

namespace GSCMasterGuide.Core.IRepositories;
public interface IAuthenticationRepository
{
    Task<bool> Register(RegisterRequest request, CancellationToken cancellationToken);

    // Task Login(LoginRequest request, CancellationToken cancellationToken);
}