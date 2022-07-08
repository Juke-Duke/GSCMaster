using GSCMaster.Core.DTOs;
using GSCMaster.Core.IRepositories;
using GSCMaster.Core.Queries.Items;
using MediatR;

namespace GSCMaster.Core.QueryHandlers.Items;
public class GetItemHandler : IRequestHandler<GetItemQuery, ItemDTO?>
{
    private readonly IItemRepository _itemRepository;

    public GetItemHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<ItemDTO?> Handle(GetItemQuery request, CancellationToken cancellationToken)
        => await _itemRepository.Get(request.Name, cancellationToken);
}