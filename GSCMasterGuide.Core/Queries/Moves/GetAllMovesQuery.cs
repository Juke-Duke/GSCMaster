using GSCMasterGuide.Core.DTOs;
using MediatR;

namespace GSCMasterGuide.Core.Queries.Moves;
public class GetAllMovesQuery : IRequest<IReadOnlyCollection<BasicMoveDTO>> {}
