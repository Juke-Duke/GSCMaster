using GSCMaster.Application.Services.Repositories;
using GSCMaster.Core.ItemAggregate;
using MongoDB.Driver;

namespace GSCMaster.Infrastructure.Services.Repositories;
public sealed class ItemRepository : IItemRepository
{
    private readonly GSCMasterDBConnection _db;

    public ItemRepository(GSCMasterDBConnection db)
        => _db = db;

    public async Task<IReadOnlyCollection<Item>> GetAllItemsAsync(CancellationToken cancellationToken)
        => await _db.Items.Find(FilterDefinition<Item>.Empty).ToListAsync(cancellationToken);

    public async Task<Item?> GetItemByNameAsync(string name, CancellationToken cancellationToken)
        => await _db.Items.Find(i => i.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync(cancellationToken);
}