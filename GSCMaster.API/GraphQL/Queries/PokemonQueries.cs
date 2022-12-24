using GSCMaster.Application.Features.PokeDex;
using GSCMaster.Core.PokemonAggregate;
using MediatR;

namespace GSCMaster.API.GraphQL.Queries;

[QueryType]
public static class PokemonQueries
{
    public static async Task<IReadOnlyCollection<Pokemon>> GetAllPokemon(
        [Service] ISender mediator,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetAllPokemonQuery(), cancellationToken);

    public static async Task<Pokemon?> GetPokemonByName(
        [Service] ISender mediator,
        string name,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetPokemonByNameQuery(name), cancellationToken);

    public static async Task<Pokemon?> GetPokemonByNationalNumber(
        [Service] ISender mediator,
        byte nationalNumber,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetPokemonByNationalNumberQuery(nationalNumber), cancellationToken);
}