using GSCMaster.Application.Repositories;
using GSCMaster.Core.Entities;
using GSCMaster.Infrastructure.Database;
using MongoDB.Driver;

namespace GSCMaster.Infrastructure.Repositories;
public sealed class TrainerRepository : ITrainerRepository
{
    private readonly GSCMasterDbContext _db;

    public TrainerRepository(GSCMasterDbContext db)
        => _db = db;

    public async Task<Trainer?> GetTrainerByEmailAsync(string email, CancellationToken cancellationToken)
        => await _db.Trainers.Find(trainer => trainer.Email.ToLower() == email.ToLower())
                             .FirstOrDefaultAsync(cancellationToken);

    public async Task AddTrainerAsync(Trainer trainer, CancellationToken cancellationToken)
        => await _db.Trainers.InsertOneAsync(trainer, cancellationToken: cancellationToken);
}