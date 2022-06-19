using GSCMasterGuide.Domain.DTOs;
using MediatR;

namespace GSCMasterGuide.API.Queries.Moves
{
    public class GetAllMovesQuery : IRequest<IReadOnlyCollection<BasicMoveDTO>> {}
}
