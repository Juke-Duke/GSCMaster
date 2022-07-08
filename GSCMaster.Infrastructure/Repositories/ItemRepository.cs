using GSCMaster.Core.DTOs;
using GSCMaster.Core.IRepositories;
using GSCMaster.Core.Mappers;
using GSCMaster.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace GSCMaster.Infrastructure.Repositories;
public class ItemRepository : IItemRepository
{
    private readonly GSCDbContext _context;

    public ItemRepository(GSCDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection<ItemDTO>> GetAll(CancellationToken cancellationToken)
        => await _context.Items.AsNoTracking()
            .Select(item => DTOMapper
            .Convert(item))
            .ToListAsync(cancellationToken);

    public async Task<ItemDTO?> Get(string name, CancellationToken cancellationToken)
    {
        var item = await _context.Items.AsNoTracking()
            .FirstOrDefaultAsync(i => i.Name == name, cancellationToken);

        return item is not null ? DTOMapper.Convert(item) : null;
    }
}