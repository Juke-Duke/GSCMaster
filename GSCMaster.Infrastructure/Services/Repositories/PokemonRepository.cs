using GSCMaster.Application.Services.Repositories;
using GSCMaster.Core.PokemonAggregate;
using MongoDB.Driver;

namespace GSCMaster.Infrastructure.Services.Repositories;
public sealed class PokemonRepository : IPokemonRepository
{
    private readonly GSCMasterDBConnection _db;

    public PokemonRepository(GSCMasterDBConnection db)
        => _db = db;

    public async Task<IReadOnlyCollection<Pokemon>> GetAllPokemonAsync(CancellationToken cancellationToken)
        => await _db.Pokemon.Find(FilterDefinition<Pokemon>.Empty)
                            .ToListAsync(cancellationToken);

    public async Task<Pokemon?> GetPokemonByNameAsync(string name, CancellationToken cancellationToken)
        => await _db.Pokemon.Find(pokemon => pokemon.Name.ToLower() == name.ToLower())
                            .FirstOrDefaultAsync(cancellationToken);

    public async Task<Pokemon?> GetPokemonByNationalNumberAsync(int nationalNumber, CancellationToken cancellationToken)
        => await _db.Pokemon.Find(pokemon => pokemon.NationalNumber == nationalNumber)
                            .FirstOrDefaultAsync(cancellationToken);
}