using GSCMasterGuide.Domain.DTOs;
using MediatR;

namespace GSCMasterGuide.Infrastructure.Queries.Items
{
    public class GetAllItemsQuery : IRequest<IReadOnlyCollection<ItemDTO>> { }
}