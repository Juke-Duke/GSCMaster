using GSCMaster.Application.IRepositories;
using GSCMaster.Core.Entities;
using GSCMaster.Infrastructure.Database;

namespace GSCMaster.Infrastructure.Repositories;
public class MoveRepository : IMoveRepository
{
    private readonly GSCMasterDBContext _db;

    public MoveRepository(GSCMasterDBContext db)
        => _db = db;

    public Task<IReadOnlyCollection<Move>> GetAllMoves(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Move?> GetMove(string name, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}