using GSCMaster.Core.DTOs;
using GSCMaster.Core.IRepositories;
using GSCMaster.Core.Mappers;
using GSCMaster.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace GSCMaster.Infrastructure.Repositories;
public class MoveRepository : IMoveRepository
{
    private readonly GSCDbContext _dbContext;

    public MoveRepository(GSCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<BasicMoveDTO>> GetAll(CancellationToken cancellationToken)
        => await _dbContext.Moves.AsNoTracking()
            .Select(move => DTOMapper
            .ConvertToBasic(move))
            .ToListAsync(cancellationToken);

    public async Task<FullMoveDTO?> Get(string name, CancellationToken cancellationToken)
        => DTOMapper
            .ConvertToFull(await _dbContext.Moves.AsNoTracking()
            .Include(move => move.EligiblePokemon)
            .FirstOrDefaultAsync(move => move.Name == name, cancellationToken));
}