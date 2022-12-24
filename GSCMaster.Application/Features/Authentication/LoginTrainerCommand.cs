using FluentValidation;
using GSCMaster.Application.Services.Authentication;
using GSCMaster.Core.Common.Primitives;
using MapsterMapper;
using MediatR;

namespace GSCMaster.Application.Features.Authentication;

public record LoginTrainerCommand
(
    string Email,
    string Password
) : IRequest<ErrorProne<AuthenticationResponse>>;

public sealed class LoginTrainerCommandValidator : AbstractValidator<LoginTrainerCommand>
{
    public LoginTrainerCommandValidator()
    {
        RuleFor(trainer => trainer.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(trainer => trainer.Password)
            .NotEmpty();
    }
}

public sealed class LoginTrainerCommandHandler : IRequestHandler<LoginTrainerCommand, ErrorProne<AuthenticationResponse>>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public LoginTrainerCommandHandler(IAuthenticationService authenticationService, IMapper mapper)
    {
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public Task<ErrorProne<AuthenticationResponse>> Handle(LoginTrainerCommand request, CancellationToken cancellationToken)
        => _authenticationService.LoginTrainerAsync(request, cancellationToken);
}