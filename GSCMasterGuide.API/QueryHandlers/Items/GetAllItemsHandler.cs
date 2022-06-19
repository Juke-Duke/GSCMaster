using GSCMasterGuide.API.Queries.Items;
using GSCMasterGuide.Domain.DTOs;
using GSCMasterGuide.Domain.IRepositories;
using MediatR;

namespace GSCMasterGuide.API.QueryHandlers.Items
{
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
}