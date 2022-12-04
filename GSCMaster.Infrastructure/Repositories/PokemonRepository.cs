using GSCMaster.Application.Repositories;
using GSCMaster.Core.Entities;
using GSCMaster.Infrastructure.Database;
using MongoDB.Driver;

namespace GSCMaster.Infrastructure.Repositories;
public sealed class PokemonRepository : IPokemonRepository
{
    private readonly GSCMasterDbContext _db;

    public PokemonRepository(GSCMasterDbContext db)
        => _db = db;

    public async Task<IReadOnlyCollection<Pokemon>> GetAllPokemonAsync(CancellationToken cancellationToken)
        => await _db.Pokemon.Find(FilterDefinition<Pokemon>.Empty)
                            .ToListAsync(cancellationToken);

    public async Task<Pokemon?> GetPokemonByNameAsync(string name, CancellationToken cancellationToken)
        => await _db.Pokemon.Find(pokemon => pokemon.Name.ToLower() == name.ToLower())
                            .FirstOrDefaultAsync(cancellationToken);
}