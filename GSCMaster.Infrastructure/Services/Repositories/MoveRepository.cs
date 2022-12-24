using GSCMaster.Application.Services.Repositories;
using GSCMaster.Core.MoveAggregate;
using MongoDB.Driver;

namespace GSCMaster.Infrastructure.Services.Repositories;
public sealed class MoveRepository : IMoveRepository
{
    private readonly GSCMasterDBConnection _db;

    public MoveRepository(GSCMasterDBConnection db)
        => _db = db;

    public async Task<IReadOnlyCollection<Move>> GetAllMovesAsync(CancellationToken cancellationToken)
        => await _db.Moves.Find(FilterDefinition<Move>.Empty).ToListAsync(cancellationToken);

    public async Task<Move?> GetMoveByNameAsync(string name, CancellationToken cancellationToken)
        => await _db.Moves.Find(m => m.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync(cancellationToken);
}