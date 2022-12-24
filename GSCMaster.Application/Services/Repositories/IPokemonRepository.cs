using GSCMaster.Core.PokemonAggregate;

namespace GSCMaster.Application.Services.Repositories;
public interface IPokemonRepository
{
    Task<IReadOnlyCollection<Pokemon>> GetAllPokemonAsync(CancellationToken cancellationToken);

    Task<Pokemon?> GetPokemonByNameAsync(string name, CancellationToken cancellationToken);

    Task<Pokemon?> GetPokemonByNationalNumberAsync(int nationalNumber, CancellationToken cancellationToken);
}