using GSCMaster.Application.IRepositories;
using MediatR;

namespace GSCMaster.Application.CQRS.Pokemon.Queries;
public record GetPokemonQuery(string Name) : IRequest<Core.Entities.Pokemon?>;

public class GetPokemonHandler : IRequestHandler<GetPokemonQuery, Core.Entities.Pokemon?>
{
    private readonly IPokemonRepository _pokemonRepository;

    public GetPokemonHandler(IPokemonRepository pokemonRepository)
        => _pokemonRepository = pokemonRepository;

    public async Task<Core.Entities.Pokemon?> Handle(GetPokemonQuery request, CancellationToken cancellationToken)
        => await _pokemonRepository.GetPokemonByNameAsync(request.Name);
}