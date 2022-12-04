using GSCMaster.Application.Repositories;
using GSCMaster.Application.Services;
using GSCMaster.Application.Services.Authentication;
using GSCMaster.Contracts.Authentication.Requests;
using GSCMaster.Contracts.Authentication.Response;
using GSCMaster.Core.Entities;

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

    public async Task<AuthenticationResponse> RegisterTrainerAsync(RegisterTrainerRequest request, CancellationToken cancellationToken)
    {
        if (request.Password != request.ConfirmPassword)
        {
            throw new Exception("Passwords do not match");
        }

        if (await _trainerRepository.GetTrainerByEmailAsync(request.Email, cancellationToken) != null)
        {
            throw new ArgumentException("Email already exists");
        }

        var trainer = new Trainer
        {
            Username = request.Username,
            Email = request.Email,
            Password = request.Password,
            CreatedAt = _dateTimeProvider.UtcNow
        };

        await _trainerRepository.AddTrainerAsync(trainer, cancellationToken);

        return new
        (
            Id: trainer.Id,
            Username: trainer.Username,
            Email: trainer.Email,
            Token: _jwtTokenGenerator.GenerateToken(trainer)
        );
    }

    public async Task<AuthenticationResponse> LoginTrainerAsync(LoginTrainerRequest request, CancellationToken cancellationToken)
    {
        if (await _trainerRepository.GetTrainerByEmailAsync(request.Email, cancellationToken) is not Trainer trainer)
        {
            throw new ArgumentException("Email does not exist");
        }

        if (trainer.Password != request.Password)
        {
            throw new ArgumentException("Password is incorrect");
        }

        return new
        (
            Id: trainer.Id,
            Username: trainer.Username,
            Email: trainer.Email,
            Token: _jwtTokenGenerator.GenerateToken(trainer)
        );
    }
}