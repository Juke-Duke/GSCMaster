using GSCMasterGuide.API.Queries.Items;
using GSCMasterGuide.Domain.DTOs;
using GSCMasterGuide.Domain.IRepositories;
using MediatR;

namespace GSCMasterGuide.API.QueryHandlers.Items
{
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
}