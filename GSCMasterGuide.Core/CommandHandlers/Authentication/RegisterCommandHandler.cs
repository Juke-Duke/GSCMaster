using GSCMasterGuide.Domain.Commands.Authentication;
using GSCMasterGuide.Domain.IRepositories;
using GSCMasterGuide.Shared.Requests.Authentication;
using GSCMasterGuide.Shared.Responses.Authentication;
using MediatR;

namespace GSCMasterGuide.Domain.CommandHandlers.Authentication
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public RegisterCommandHandler(IAuthenticationRepository authenticationRepository)
            => _authenticationRepository = authenticationRepository;

        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
            => await _authenticationRepository.Register(new RegisterRequest(request.Email, request.Username, request.Password, request.ConfirmPassword), cancellationToken);
    }
}
