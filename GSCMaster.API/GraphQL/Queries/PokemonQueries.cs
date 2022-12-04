using GSCMaster.Application.CQRS.Pokemon.Queries;
using GSCMaster.Core.Entities;
using MediatR;

namespace GSCMaster.API.GraphQL.Queries;

[ExtendObjectType(OperationTypeNames.Query)]
public sealed class PokemonQueries
{
    public async Task<IReadOnlyCollection<Pokemon>> GetAllPokemon([Service] ISender mediator, CancellationToken cancellationToken)
        => await mediator.Send(new GetAllPokemonQuery(), cancellationToken);

    public async Task<Pokemon?> GetPokemonByName([Service] ISender mediator, string name, CancellationToken cancellationToken)
        => await mediator.Send(new GetPokemonByNameQuery(name), cancellationToken);
}