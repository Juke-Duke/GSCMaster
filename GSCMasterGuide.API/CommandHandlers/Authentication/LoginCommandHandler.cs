using GSCMasterGuide.API.Commands.Authentication;
using GSCMasterGuide.Domain.IRepositories;
using GSCMasterGuide.Shared.Requests.Authentication;
using GSCMasterGuide.Shared.Responses.Authentication;
using MediatR;

namespace GSCMasterGuide.API.CommandHandlers.Authentication
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public LoginCommandHandler(IAuthenticationRepository authenticationRepository)
            => _authenticationRepository = authenticationRepository;

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
            => await _authenticationRepository.Login(new LoginRequest(request.Username, request.Password), cancellationToken);
    }
}