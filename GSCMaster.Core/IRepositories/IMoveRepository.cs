using GSCMaster.Core.DTOs;

namespace GSCMaster.Core.IRepositories;
public interface IMoveRepository
{
    Task<IReadOnlyCollection<BasicMoveDTO>> GetAll(CancellationToken cancellationToken);

    Task<FullMoveDTO?> Get(string name, CancellationToken cancellationToken);
}