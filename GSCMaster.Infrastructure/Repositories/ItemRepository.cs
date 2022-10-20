using GSCMaster.Core.Entities;
using GSCMaster.Application.IRepositories;
using GSCMaster.Infrastructure.Database;

namespace GSCMaster.Infrastructure.Repositories;
public sealed class ItemRepository : IItemRepository
{
    private readonly GSCMasterDBContext _db;

    public ItemRepository(GSCMasterDBContext db)
        => _db = db;

    public Task<IReadOnlyCollection<Item>> GetAllItemsAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Item?> GetItemAsync(string name, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}