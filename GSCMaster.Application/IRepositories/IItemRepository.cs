using GSCMaster.Core.Entities;

namespace GSCMaster.Application.IRepositories;
public interface IItemRepository
{
    Task<IReadOnlyCollection<Item>> GetAllItems(CancellationToken cancellationToken);

    Task<Item?> GetItem(string name, CancellationToken cancellationToken);
}