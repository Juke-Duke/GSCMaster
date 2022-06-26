using GSCMasterGuide.Core.DTOs;
using GSCMasterGuide.Core.IRepositories;
using GSCMasterGuide.Core.Queries.Items;
using MediatR;

namespace GSCMasterGuide.Core.QueryHandlers.Items;
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