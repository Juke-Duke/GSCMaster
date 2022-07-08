using GSCMaster.Core.DTOs;
using MediatR;

namespace GSCMaster.Core.Queries.Moves;
public class GetAllMovesQuery : IRequest<IReadOnlyCollection<BasicMoveDTO>> { }
