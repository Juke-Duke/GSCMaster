using GSCMaster.Application.Features.Resources.ItemDex;
using GSCMaster.Core.ItemAggregate;
using MediatR;

namespace GSCMaster.API.GraphQL.Queries;

[QueryType]
public static class ItemQueries
{
    public static async Task<IReadOnlyCollection<Item>> GetAllItems(
        [Service] ISender mediator,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetAllItemsQuery(), cancellationToken);

    public static async Task<Item?> GetItemByName(
        [Service] ISender mediator,
        string name,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetItemByNameQuery(name), cancellationToken);
}