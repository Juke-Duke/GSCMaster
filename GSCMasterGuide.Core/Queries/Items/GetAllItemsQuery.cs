using GSCMasterGuide.Core.DTOs;
using MediatR;

namespace GSCMasterGuide.Core.Queries.Items;
public class GetAllItemsQuery : IRequest<IReadOnlyCollection<ItemDTO>> {}