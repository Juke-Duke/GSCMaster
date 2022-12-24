using GSCMaster.Core.TrainerAggregate;

namespace GSCMaster.Application.Services.Repositories;
public interface ITrainerRepository
{
    Task<Trainer?> GetTrainerByEmailAsync(string email, CancellationToken cancellationToken);

    Task AddTrainerAsync(Trainer trainer, CancellationToken cancellationToken);
}