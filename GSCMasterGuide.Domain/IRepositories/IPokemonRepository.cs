using GSCMasterGuide.Domain.DTOs;

namespace GSCMasterGuide.Domain.IRepositories
{
    public interface IPokemonRepository
    {
        Task<IReadOnlyCollection<BasicPokemonDTO>> GetAll(CancellationToken cancellationToken);
    }
}
