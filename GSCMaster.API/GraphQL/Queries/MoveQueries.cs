using GSCMaster.Application.CQRS.Moves.Queries;
using GSCMaster.Core.Entities;
using MediatR;

namespace GSCMaster.API.GraphQL.Queries;

[ExtendObjectType(OperationTypeNames.Query)]
public sealed class MoveQueries
{
    public async Task<IReadOnlyCollection<Move>> GetAllMoves([Service] ISender mediator, CancellationToken cancellationToken)
        => await mediator.Send(new GetAllMovesQuery(), cancellationToken);

    public async Task<Move?> GetMoveByName([Service] ISender mediator, string name, CancellationToken cancellationToken)
        => await mediator.Send(new GetMoveByNameQuery(name), cancellationToken);
}