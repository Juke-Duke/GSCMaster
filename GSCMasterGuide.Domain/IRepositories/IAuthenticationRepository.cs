using GSCMasterGuide.Shared.Requests.Authentication;
using GSCMasterGuide.Shared.Responses.Authentication;

namespace GSCMasterGuide.Domain.IRepositories
{
    public interface IAuthenticationRepository
    {
        Task<RegisterResponse> Register(RegisterRequest request, CancellationToken cancellationToken);

        Task<LoginResponse> Login(LoginRequest request, CancellationToken cancellationToken);
    }
}
