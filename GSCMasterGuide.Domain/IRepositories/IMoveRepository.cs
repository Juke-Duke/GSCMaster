using GSCMasterGuide.Domain.DTOs;

namespace GSCMasterGuide.Domain.IRepositories
{
    public interface IMoveRepository
    {
        Task<IReadOnlyCollection<BasicMoveDTO>> GetAll(CancellationToken cancellationToken);

        Task<FullMoveDTO?> Get(string name, CancellationToken cancellationToken);
    }
}
