using GSCMaster.Core.Entities;

namespace GSCMaster.Application.Repositories;
public interface IItemRepository
{
    Task<IReadOnlyCollection<Item>> GetAllItemsAsync(CancellationToken cancellationToken);

    Task<Item?> GetItemByNameAsync(string name, CancellationToken cancellationToken);
}