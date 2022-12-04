using FluentValidation;
using GSCMaster.Application.Repositories;
using GSCMaster.Core.Entities;
using MediatR;

namespace GSCMaster.Application.CQRS.Items.Queries;
public sealed record GetAllItemsQuery : IRequest<IReadOnlyCollection<Item>>;

public sealed class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, IReadOnlyCollection<Item>>
{
    private readonly IItemRepository _itemRepository;

    public GetAllItemsQueryHandler(IItemRepository itemRepository)
        => _itemRepository = itemRepository;

    public async Task<IReadOnlyCollection<Item>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        => await _itemRepository.GetAllItemsAsync(cancellationToken);
}