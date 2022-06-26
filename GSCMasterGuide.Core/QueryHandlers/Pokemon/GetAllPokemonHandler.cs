using GSCMasterGuide.Core.DTOs;
using GSCMasterGuide.Core.IRepositories;
using GSCMasterGuide.Core.Queries.Pokemon;
using MediatR;

namespace GSCMasterGuide.Core.QueryHandlers.Pokemon;
public class GetAllPokemonHandler : IRequestHandler<GetAllPokemonQuery, IReadOnlyCollection<BasicPokemonDTO>>
{
    private readonly IPokemonRepository _pokemonRepository;

    public GetAllPokemonHandler(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }

    public async Task<IReadOnlyCollection<BasicPokemonDTO>> Handle(GetAllPokemonQuery request, CancellationToken cancellationToken)
        => await _pokemonRepository.GetAll(cancellationToken);
}