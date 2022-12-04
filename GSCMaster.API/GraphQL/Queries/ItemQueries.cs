using GSCMaster.Application.CQRS.Items.Queries;
using GSCMaster.Core.Entities;
using MediatR;

namespace GSCMaster.API.GraphQL.Queries;

[ExtendObjectType(OperationTypeNames.Query)]
public sealed class ItemQueries
{
    public async Task<IReadOnlyCollection<Item>> GetAllItems([Service] ISender mediator, CancellationToken cancellationToken)
        => await mediator.Send(new GetAllItemsQuery(), cancellationToken);

    public async Task<Item?> GetItemByName([Service] ISender mediator, string name, CancellationToken cancellationToken)
        => await mediator.Send(new GetItemByNameQuery(name), cancellationToken);
}