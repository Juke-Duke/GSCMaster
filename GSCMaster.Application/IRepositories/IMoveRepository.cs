using GSCMaster.Core.Entities;

namespace GSCMaster.Application.IRepositories;
public interface IMoveRepository
{
    Task<IReadOnlyCollection<Move>> GetAllMovesAsync(CancellationToken cancellationToken);

    Task<Move?> GetMoveAsync(string name, CancellationToken cancellationToken);
}