using GSCMaster.Application.IRepositories;
using MediatR;

namespace GSCMaster.Application.CQRS.Pokemon.Queries;
public record GetAllPokemonQuery : IRequest<IReadOnlyCollection<Core.Entities.Pokemon>>;

public class GetAllPokemonHandler : IRequestHandler<GetAllPokemonQuery, IReadOnlyCollection<Core.Entities.Pokemon>>
{
    private readonly IPokemonRepository _pokemonRepository;

    public GetAllPokemonHandler(IPokemonRepository pokemonRepository)
        => _pokemonRepository = pokemonRepository;

    public async Task<IReadOnlyCollection<Core.Entities.Pokemon>> Handle(GetAllPokemonQuery request, CancellationToken cancellationToken)
        => await _pokemonRepository.GetAllPokemonAsync();
}