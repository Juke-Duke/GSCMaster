using GSCMaster.Application.IRepositories;
using HotChocolate;
using MediatR;

namespace GSCMaster.Application.CQRS.Pokemon.Queries;
public class GetAllPokemonHandler : IRequestHandler<GetAllPokemonQuery, IReadOnlyCollection<Core.Entities.Pokemon>>
{
    private readonly IPokemonRepository _pokemonRepository;

    public GetAllPokemonHandler(IPokemonRepository pokemonRepository)
        => _pokemonRepository = pokemonRepository;

    public Task<IReadOnlyCollection<Core.Entities.Pokemon>> Handle(GetAllPokemonQuery request, CancellationToken cancellationToken)
        => _pokemonRepository.GetAllPokemon();
}