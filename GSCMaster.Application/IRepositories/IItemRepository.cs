using GSCMaster.Core.Entities;

namespace GSCMaster.Application.IRepositories;
public interface IItemRepository
{
    Task<IReadOnlyCollection<Item>> GetAllItemsAsync(CancellationToken cancellationToken);

    Task<Item?> GetItemAsync(string name, CancellationToken cancellationToken);
}