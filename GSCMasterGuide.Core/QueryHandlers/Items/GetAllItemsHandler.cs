using GSCMasterGuide.Core.DTOs;
using GSCMasterGuide.Core.IRepositories;
using GSCMasterGuide.Core.Queries.Items;
using MediatR;

namespace GSCMasterGuide.Core.QueryHandlers.Items;
public class GetAllItemsHandler : IRequestHandler<GetAllItemsQuery, IReadOnlyCollection<ItemDTO>>
{
    private readonly IItemRepository _itemRepository;

    public GetAllItemsHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<IReadOnlyCollection<ItemDTO>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        => await _itemRepository.GetAll(cancellationToken);
}