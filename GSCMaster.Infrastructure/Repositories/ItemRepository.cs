using GSCMaster.Core.Entities;
using GSCMaster.Application.IRepositories;
using GSCMaster.Infrastructure.Database;

namespace GSCMaster.Infrastructure.Repositories;
public class ItemRepository : IItemRepository
{
    private readonly GSCMasterDBContext _db;

    public ItemRepository(GSCMasterDBContext db)
        => _db = db;

    public Task<IReadOnlyCollection<Item>> GetAllItems(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Item?> GetItem(string name, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}