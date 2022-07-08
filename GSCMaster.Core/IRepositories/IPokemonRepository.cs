using GSCMaster.Core.DTOs;

namespace GSCMaster.Core.IRepositories;
public interface IPokemonRepository
{
    Task<IReadOnlyCollection<BasicPokemonDTO>> GetAll(CancellationToken cancellationToken);

    Task<FullPokemonDTO?> Get(string name, CancellationToken cancellationToken);
}