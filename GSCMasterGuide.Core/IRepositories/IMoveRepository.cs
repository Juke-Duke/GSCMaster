using GSCMasterGuide.Core.DTOs;

namespace GSCMasterGuide.Core.IRepositories;
public interface IMoveRepository
{
    Task<IReadOnlyCollection<BasicMoveDTO>> GetAll(CancellationToken cancellationToken);

    Task<FullMoveDTO?> Get(string name, CancellationToken cancellationToken);
}