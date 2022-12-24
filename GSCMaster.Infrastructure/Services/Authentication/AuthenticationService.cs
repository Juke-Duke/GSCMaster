using GSCMaster.Application.Features.Authentication;
using GSCMaster.Application.Services;
using GSCMaster.Application.Services.Authentication;
using GSCMaster.Application.Services.Repositories;
using GSCMaster.Core.Common.Errors;
using GSCMaster.Core.Common.Primitives;
using GSCMaster.Core.TrainerAggregate;

namespace GSCMaster.Infrastructure.Services.Authentication;
public class AuthenticationService : IAuthenticationService
{
    private readonly ITrainerRepository _trainerRepository;
    private readonly IJWTGenerator _jwtTokenGenerator;
    private readonly IDateTimeProvider _dateTimeProvider;

    public AuthenticationService(ITrainerRepository trainerRepository, IJWTGenerator jwtTokenGenerator, IDateTimeProvider dateTimeProvider)
    {
        _trainerRepository = trainerRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ErrorProne<AuthenticationResponse>> RegisterTrainerAsync(RegisterTrainerCommand request, CancellationToken cancellationToken)
    {
        var errors = new List<Error>();

        if (await _trainerRepository.GetTrainerByEmailAsync(request.Email, cancellationToken) is not null)
            errors.Add(AuthenticationErrors.EmailAlreadyExists);

        if (request.Password != request.ConfirmPassword)
            errors.Add(AuthenticationErrors.UnconfirmedPassword);

        if (errors.Any())
            return errors;

        var trainer = new Trainer
        (
            username: request.Username,
            email: request.Email,
            password: request.Password,
            createdAt: _dateTimeProvider.UtcNow
        );

        await _trainerRepository.AddTrainerAsync(trainer, cancellationToken);

        return new AuthenticationResponse
        (
            Id: trainer.Id,
            Username: trainer.Username,
            Email: trainer.Email,
            Token: _jwtTokenGenerator.GenerateToken(trainer)
        );
    }

    public async Task<ErrorProne<AuthenticationResponse>> LoginTrainerAsync(LoginTrainerCommand request, CancellationToken cancellationToken)
    {
        var trainer = await _trainerRepository.GetTrainerByEmailAsync(request.Email, cancellationToken);

        if (trainer is null || trainer.Password != request.Password)
            return AuthenticationErrors.InvalidLogin;

        return new AuthenticationResponse
        (
            Id: trainer.Id,
            Username: trainer.Username,
            Email: trainer.Email,
            Token: _jwtTokenGenerator.GenerateToken(trainer)
        );
    }
}