using GSCMaster.Core.ItemAggregate;

namespace GSCMaster.Application.Services.Repositories;
public interface IItemRepository
{
    Task<IReadOnlyCollection<Item>> GetAllItemsAsync(CancellationToken cancellationToken);

    Task<Item?> GetItemByNameAsync(string name, CancellationToken cancellationToken);
}