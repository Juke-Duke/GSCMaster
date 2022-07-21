// using GSCMaster.Core.IRepositories;
// using GSCMaster.Core.Commands.Authentication;
// using GSCMaster.Shared.Requests.Authentication;
// using MediatR;

// namespace GSCMaster.Core.CommandHandlers.Authentication;
// public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
// {
//     private readonly IAuthenticationRepository _authenticationRepository;

//     public RegisterCommandHandler(IAuthenticationRepository authenticationRepository)
//         => _authenticationRepository = authenticationRepository;

//     public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
//         => await _authenticationRepository.Register(new RegisterRequest
//         {
//             Email = request.Email,
//             Username = request.Username,
//             Password = request.Password,
//             ConfirmPassword = request.ConfirmPassword
//         }, cancellationToken);
// }