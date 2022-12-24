using FluentValidation;
using GSCMaster.Application.Services.Authentication;
using GSCMaster.Core.Common.Primitives;
using MapsterMapper;
using MediatR;

namespace GSCMaster.Application.Features.Authentication;

public record RegisterTrainerCommand
(
    string Username,
    string Email,
    string Password,
    string ConfirmPassword
) : IRequest<ErrorProne<AuthenticationResponse>>;

public sealed class RegisterTrainerCommandValidator : AbstractValidator<RegisterTrainerCommand>
{
    public RegisterTrainerCommandValidator()
    {
        RuleFor(trainer => trainer.Username)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(trainer => trainer.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(trainer => trainer.Password)
            .NotEmpty()
            .MinimumLength(8);

        RuleFor(trainer => trainer.ConfirmPassword)
            .NotEmpty()
            .Equal(trainer => trainer.Password);
    }
}

public sealed class RegisterTrainerHandler : IRequestHandler<RegisterTrainerCommand, ErrorProne<AuthenticationResponse>>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public RegisterTrainerHandler(IAuthenticationService authenticationService, IMapper mapper)
    {
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public Task<ErrorProne<AuthenticationResponse>> Handle(RegisterTrainerCommand request, CancellationToken cancellationToken)
        => _authenticationService.RegisterTrainerAsync(request, cancellationToken);
}