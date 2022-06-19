using GSCMasterGuide.Domain.DTOs;

namespace GSCMasterGuide.Domain.IRepositories
{
    public interface IItemRepository
    {
        Task<IReadOnlyCollection<ItemDTO>> GetAll(CancellationToken cancellationToken);

        Task<ItemDTO?> Get(string name, CancellationToken cancellationToken);
    }
}
