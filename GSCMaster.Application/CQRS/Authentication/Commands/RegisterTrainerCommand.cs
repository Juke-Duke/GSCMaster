using FluentValidation;
using GSCMaster.Application.Services.Authentication;
using GSCMaster.Contracts.Authentication.Requests;
using GSCMaster.Contracts.Authentication.Response;
using MapsterMapper;
using MediatR;

namespace GSCMaster.Application.CQRS.Authentication.Commands;

public record RegisterTrainerCommand
(
    string Username,
    string Email,
    string Password,
    string ConfirmPassword
) : IRequest<AuthenticationResponse>;

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

public sealed class RegisterTrainerHandler : IRequestHandler<RegisterTrainerCommand, AuthenticationResponse>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public RegisterTrainerHandler(IAuthenticationService authenticationService, IMapper mapper)
    {
        _authenticationService = authenticationService;
        _mapper = mapper;
    }

    public Task<AuthenticationResponse> Handle(RegisterTrainerCommand request, CancellationToken cancellationToken)
        => _authenticationService.RegisterTrainerAsync(_mapper.Map<RegisterTrainerRequest>(request), cancellationToken);
}