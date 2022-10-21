using GSCMaster.Application.CQRS.Pokemon.Queries;
using GSCMaster.Core.Entities;
using MediatR;

namespace GSCMaster.API.GraphQL.Queries;
public sealed class PokemonQueries
{
    public async Task<IReadOnlyCollection<Pokemon>> GetAllPokemon(IMediator mediator, CancellationToken cancellationToken)
        => await mediator.Send(new GetAllPokemonQuery(), cancellationToken);

    public async Task<Pokemon?> GetPokemonByName(IMediator mediator, string name, CancellationToken cancellationToken)
        => await mediator.Send(new GetPokemonQuery(name), cancellationToken);
}