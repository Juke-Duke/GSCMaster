using GSCMasterGuide.Core.DTOs;
using GSCMasterGuide.Core.IRepositories;
using GSCMasterGuide.Core.Queries.Pokemon;
using MediatR;

namespace GSCMasterGuide.Core.QueryHandlers.Pokemon;
public class GetPokemonHandler : IRequestHandler<GetPokemonQuery, FullPokemonDTO?>
{
    private readonly IPokemonRepository _pokemonRepository;

    public GetPokemonHandler(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }

    public async Task<FullPokemonDTO?> Handle(GetPokemonQuery request, CancellationToken cancellationToken)
        => await _pokemonRepository.Get(request.Name, cancellationToken);
}