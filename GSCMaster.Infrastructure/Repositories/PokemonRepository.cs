using GSCMaster.Application.IRepositories;
using GSCMaster.Core.Entities;
using GSCMaster.Infrastructure.Database;
using HotChocolate;
using HotChocolate.Data;
using MongoDB.Driver;

namespace GSCMaster.Infrastructure.Repositories;
public class PokemonRepository : IPokemonRepository
{
    private readonly GSCMasterDBContext _db;

    public PokemonRepository(GSCMasterDBContext db)
        => _db = db;

    public async Task<IReadOnlyCollection<Pokemon>> GetAllPokemon()
        => await _db.Pokemon.Find(FilterDefinition<Pokemon>.Empty).ToListAsync();

    public async Task<Pokemon?> GetPokemonByName(string name)
        => await _db.Pokemon.Find(p => p.Name == name).FirstOrDefaultAsync();
}