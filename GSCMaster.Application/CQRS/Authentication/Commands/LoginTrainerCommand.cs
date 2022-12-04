using FluentValidation;
using GSCMaster.Application.Services.Authentication;
using GSCMaster.Contracts.Authentication.Requests;
using GSCMaster.Contracts.Authentication.Response;
using MapsterMapper;
using MediatR;

namespace GSCMaster.Application.CQRS.Authentication.Commands;

public record LoginTrainerCommand
(
    string Username,
    string Email,
    string Password
) : IRequest<AuthenticationResponse>;

public sealed class LoginTrainerCommandValidator : AbstractValidator<LoginTrainerCommand>
{
    public LoginTrainerCommandValidator()
    {
        RuleFor(trainer => trainer.Username)
            .NotEmpty();

        RuleFor(trainer => trainer.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(trainer => trainer.Password)
            .NotEmpty();
    }
}

public sealed class LoginTrainerCommandHandler : IRequestHandler<LoginTrainerCommand, AuthenticationResponse>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public LoginTrainerCommandHandler(IAuthenticationService authenticationService, IMapper mapper)
    {
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public Task<AuthenticationResponse> Handle(LoginTrainerCommand request, CancellationToken cancellationToken)
        => _authenticationService.LoginTrainerAsync(_mapper.Map<LoginTrainerRequest>(request), cancellationToken);
}