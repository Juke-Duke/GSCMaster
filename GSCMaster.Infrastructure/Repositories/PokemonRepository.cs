using GSCMaster.Core.DTOs;
using GSCMaster.Core.IRepositories;
using GSCMaster.Core.Mappers;
using GSCMaster.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace GSCMaster.Infrastructure.Repositories;
public class PokemonRepository : IPokemonRepository
{
    private readonly GSCDbContext _dbContext;

    public PokemonRepository(GSCDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<BasicPokemonDTO>> GetAll(CancellationToken cancellationToken)
        => await _dbContext.Pokemon.AsNoTracking()
            .Select(pokemon => DTOMapper
            .ConvertToBasic(pokemon))
            .ToListAsync(cancellationToken);

    public async Task<FullPokemonDTO?> Get(string name, CancellationToken cancellationToken)
        => DTOMapper
            .ConvertToFull(await _dbContext.Pokemon
            .Include(pokemon => pokemon.PreEvolution)
            .ThenInclude(preEvo => preEvo != null ? preEvo.Evolution : null)
            .Include(pokemon => pokemon.PreEvolution != null ? pokemon.PreEvolution.PreEvolution : null)
            .Include(pokemon => pokemon.Evolution)
            .ThenInclude(evo => evo.Evolution)
            .FirstOrDefaultAsync(pokemon => pokemon.Name == name, cancellationToken));
}