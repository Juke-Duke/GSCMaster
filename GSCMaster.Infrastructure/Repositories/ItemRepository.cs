using GSCMaster.Core.Entities;
using GSCMaster.Application.Repositories;
using GSCMaster.Infrastructure.Database;
using MongoDB.Driver;

namespace GSCMaster.Infrastructure.Repositories;
public sealed class ItemRepository : IItemRepository
{
    private readonly GSCMasterDbContext _db;

    public ItemRepository(GSCMasterDbContext db)
        => _db = db;

    public async Task<IReadOnlyCollection<Item>> GetAllItemsAsync(CancellationToken cancellationToken)
        => await _db.Items.Find(FilterDefinition<Item>.Empty).ToListAsync(cancellationToken);

    public async Task<Item?> GetItemByNameAsync(string name, CancellationToken cancellationToken)
        => await _db.Items.Find(i => i.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync(cancellationToken);
}