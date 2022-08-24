using GSCMaster.Application.Helpers;
using GSCMaster.Application.IRepositories;
using GSCMaster.Contracts.Responses;
using MediatR;

namespace GSCMaster.Application.CQRS.Pokemon.Queries;
public record GetPokemonQuery(string Name) : IRequest<PokemonResponse?>;

public class GetPokemonHandler : IRequestHandler<GetPokemonQuery, PokemonResponse?>
{
    private readonly IPokemonRepository _pokemonRepository;

    public GetPokemonHandler(IPokemonRepository pokemonRepository)
        => _pokemonRepository = pokemonRepository;

    public async Task<PokemonResponse?> Handle(GetPokemonQuery request, CancellationToken cancellationToken)
    {
        var pokemon = await _pokemonRepository.GetPokemonByNameAsync(request.Name);

        return pokemon?.ToResponse();
    }
}