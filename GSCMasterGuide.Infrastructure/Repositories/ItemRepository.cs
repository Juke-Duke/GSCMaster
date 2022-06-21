using GSCMasterGuide.Domain.DTOs;
using GSCMasterGuide.Domain.IRepositories;
using GSCMasterGuide.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GSCMasterGuide.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly GSCDbContext _context;

        public ItemRepository(GSCDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<ItemDTO>> GetAll(CancellationToken cancellationToken)
            => await _context.Items.AsNoTracking()
                .Select(item => DTOConverter
                .Convert(item))
                .ToListAsync(cancellationToken);

        public async Task<ItemDTO?> Get(string name, CancellationToken cancellationToken)
        {
            var item = await _context.Items.AsNoTracking()
                .FirstOrDefaultAsync(i => i.Name == name, cancellationToken);

            return item is not null ? DTOConverter.Convert(item) : null;
        }
    }
}
