using GSCMaster.Core.Entities;

namespace GSCMaster.Application.IRepositories;
public interface IMoveRepository
{
    Task<IReadOnlyCollection<Move>> GetAllMoves(CancellationToken cancellationToken);

    Task<Move?> GetMove(string name, CancellationToken cancellationToken);
}