using GSCMaster.Application.Services.Repositories;
using GSCMaster.Core.TrainerAggregate;
using MongoDB.Driver;

namespace GSCMaster.Infrastructure.Services.Repositories;
public sealed class TrainerRepository : ITrainerRepository
{
    private readonly GSCMasterDBConnection _db;

    public TrainerRepository(GSCMasterDBConnection db)
        => _db = db;

    public async Task<Trainer?> GetTrainerByEmailAsync(string email, CancellationToken cancellationToken)
        => await _db.Trainers.Find(trainer => trainer.Email.ToLower() == email.ToLower())
                             .FirstOrDefaultAsync(cancellationToken);

    public async Task AddTrainerAsync(Trainer trainer, CancellationToken cancellationToken)
        => await _db.Trainers.InsertOneAsync(trainer, cancellationToken: cancellationToken);
}