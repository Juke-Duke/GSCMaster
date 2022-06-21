using GSCMasterGuide.Domain.DTOs;
using MediatR;

namespace GSCMasterGuide.Infrastructure.Queries.Moves
{
    public class GetAllMovesQuery : IRequest<IReadOnlyCollection<BasicMoveDTO>> { }
}
