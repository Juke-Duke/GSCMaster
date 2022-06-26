using GSCMasterGuide.Core.DTOs;

namespace GSCMasterGuide.Core.IRepositories;
public interface IPokemonRepository
{
    Task<IReadOnlyCollection<BasicPokemonDTO>> GetAll(CancellationToken cancellationToken);

    Task<FullPokemonDTO?> Get(string name, CancellationToken cancellationToken);
}