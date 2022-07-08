using GSCMaster.Core.DTOs;
using GSCMaster.Core.IRepositories;
using GSCMaster.Core.Queries.Pokemon;
using MediatR;

namespace GSCMaster.Core.QueryHandlers.Pokemon;
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