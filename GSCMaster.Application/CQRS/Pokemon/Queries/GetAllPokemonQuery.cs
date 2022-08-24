using GSCMaster.Application.Helpers;
using GSCMaster.Application.IRepositories;
using GSCMaster.Contracts.Responses;
using MediatR;

namespace GSCMaster.Application.CQRS.Pokemon.Queries;
public record GetAllPokemonQuery : IRequest<IReadOnlyCollection<PokemonResponse>>;

public class GetAllPokemonHandler : IRequestHandler<GetAllPokemonQuery, IReadOnlyCollection<PokemonResponse>>
{
    private readonly IPokemonRepository _pokemonRepository;

    public GetAllPokemonHandler(IPokemonRepository pokemonRepository)
        => _pokemonRepository = pokemonRepository;

    public async Task<IReadOnlyCollection<PokemonResponse>> Handle(GetAllPokemonQuery request, CancellationToken cancellationToken)
    {
        var pokemon = await _pokemonRepository.GetAllPokemonAsync();

        return pokemon.Select(p => p.ToResponse()).ToList();
    }
}