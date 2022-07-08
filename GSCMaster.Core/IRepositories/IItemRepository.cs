using GSCMaster.Core.DTOs;

namespace GSCMaster.Core.IRepositories;
public interface IItemRepository
{
    Task<IReadOnlyCollection<ItemDTO>> GetAll(CancellationToken cancellationToken);

    Task<ItemDTO?> Get(string name, CancellationToken cancellationToken);
}