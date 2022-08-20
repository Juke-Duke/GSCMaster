using GSCMaster.Application.IRepositories;
using HotChocolate;
using MediatR;

namespace GSCMaster.Application.CQRS.Pokemon.Queries;
public class GetPokemonHandler : IRequestHandler<GetPokemonQuery, Core.Entities.Pokemon?>
{
    private readonly IPokemonRepository _pokemonRepository;

    public GetPokemonHandler(IPokemonRepository pokemonRepository)
        => _pokemonRepository = pokemonRepository;

    public Task<Core.Entities.Pokemon?> Handle(GetPokemonQuery request, CancellationToken cancellationToken)
        =>_pokemonRepository.GetPokemonByName(request.Name);
}