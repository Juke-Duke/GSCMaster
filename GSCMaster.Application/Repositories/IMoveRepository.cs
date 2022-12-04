using GSCMaster.Core.Entities;

namespace GSCMaster.Application.Repositories;
public interface IMoveRepository
{
    Task<IReadOnlyCollection<Move>> GetAllMovesAsync(CancellationToken cancellationToken);

    Task<Move?> GetMoveByNameAsync(string name, CancellationToken cancellationToken);
}