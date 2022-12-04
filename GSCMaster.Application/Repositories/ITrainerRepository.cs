using GSCMaster.Core.Entities;

namespace GSCMaster.Application.Repositories;
public interface ITrainerRepository
{
    Task<Trainer?> GetTrainerByEmailAsync(string email, CancellationToken cancellationToken);

    Task AddTrainerAsync(Trainer trainer, CancellationToken cancellationToken);
}