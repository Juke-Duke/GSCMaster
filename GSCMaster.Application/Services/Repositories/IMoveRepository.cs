
using GSCMaster.Core.MoveAggregate;

namespace GSCMaster.Application.Services.Repositories;
public interface IMoveRepository
{
    Task<IReadOnlyCollection<Move>> GetAllMovesAsync(CancellationToken cancellationToken);

    Task<Move?> GetMoveByNameAsync(string name, CancellationToken cancellationToken);
}