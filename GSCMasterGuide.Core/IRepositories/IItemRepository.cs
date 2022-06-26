using GSCMasterGuide.Core.DTOs;

namespace GSCMasterGuide.Core.IRepositories;
public interface IItemRepository
{
    Task<IReadOnlyCollection<ItemDTO>> GetAll(CancellationToken cancellationToken);

    Task<ItemDTO?> Get(string name, CancellationToken cancellationToken);
}