using GSCMaster.Application.CQRS.Pokemon.Queries;
using GSCMaster.Contracts.Responses;
using MediatR;

namespace GSCMaster.API.GraphQL.Queries;
public class PokemonQueries
{
    public async Task<IReadOnlyCollection<PokemonResponse>> GetAllPokemon([Service] IMediator mediator, CancellationToken cancellationToken)
        => await mediator.Send(new GetAllPokemonQuery(), cancellationToken);

    public async Task<PokemonResponse?> GetPokemonByName([Service] IMediator mediator, string name, CancellationToken cancellationToken)
        => await mediator.Send(new GetPokemonQuery(name), cancellationToken);
}