using GSCMaster.Core.DTOs;
using MediatR;

namespace GSCMaster.Core.Queries.Items;
public class GetAllItemsQuery : IRequest<IReadOnlyCollection<ItemDTO>> { }