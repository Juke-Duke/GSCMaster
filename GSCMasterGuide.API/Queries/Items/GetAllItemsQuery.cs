using GSCMasterGuide.Domain.DTOs;
using MediatR;

namespace GSCMasterGuide.API.Queries.Items
{
    public class GetAllItemsQuery : IRequest<IReadOnlyCollection<ItemDTO>> {}
}