using GSCMaster.Core.Entities;

namespace GSCMaster.Application.Repositories;
public interface IPokemonRepository
{
    Task<IReadOnlyCollection<Pokemon>> GetAllPokemonAsync(CancellationToken cancellationToken);

    Task<Pokemon?> GetPokemonByNameAsync(string name, CancellationToken cancellationToken);
}