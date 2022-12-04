using GSCMaster.Application.Repositories;
using GSCMaster.Core.Entities;
using GSCMaster.Infrastructure.Database;
using MongoDB.Driver;

namespace GSCMaster.Infrastructure.Repositories;
public sealed class MoveRepository : IMoveRepository
{
    private readonly GSCMasterDbContext _db;

    public MoveRepository(GSCMasterDbContext db)
        => _db = db;

    public async Task<IReadOnlyCollection<Move>> GetAllMovesAsync(CancellationToken cancellationToken)
        => await _db.Moves.Find(FilterDefinition<Move>.Empty).ToListAsync(cancellationToken);

    public async Task<Move?> GetMoveByNameAsync(string name, CancellationToken cancellationToken)
        => await _db.Moves.Find(m => m.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync(cancellationToken);
}