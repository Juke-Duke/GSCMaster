using GSCMaster.Application.Features.Resources.MoveDex;
using GSCMaster.Core.MoveAggregate;
using MediatR;

namespace GSCMaster.API.GraphQL.Queries;

[QueryType]
public static class MoveQueries
{
    public static async Task<IReadOnlyCollection<Move>> GetAllMoves(
        [Service] ISender mediator,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetAllMovesQuery(), cancellationToken);

    public static async Task<Move?> GetMoveByName(
        [Service] ISender mediator,
        string name,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetMoveByNameQuery(name), cancellationToken);
}