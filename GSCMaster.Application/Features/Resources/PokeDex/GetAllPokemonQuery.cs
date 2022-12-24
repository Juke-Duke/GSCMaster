using GSCMaster.Application.Services.Repositories;
using GSCMaster.Core.PokemonAggregate;
using MediatR;


namespace GSCMaster.Application.Features.PokeDex;
public sealed record GetAllPokemonQuery : IRequest<IReadOnlyCollection<Pokemon>>;

public sealed class GetAllPokemonHandler : IRequestHandler<GetAllPokemonQuery, IReadOnlyCollection<Pokemon>>
{
    private readonly IPokemonRepository _pokemonRepository;

    public GetAllPokemonHandler(IPokemonRepository pokemonRepository)
        => _pokemonRepository = pokemonRepository;

    public async Task<IReadOnlyCollection<Pokemon>> Handle(GetAllPokemonQuery request, CancellationToken cancellationToken)
        => await _pokemonRepository.GetAllPokemonAsync(cancellationToken);
}