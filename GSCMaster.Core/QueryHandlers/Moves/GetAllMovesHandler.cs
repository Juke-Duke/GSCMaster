using GSCMaster.Core.DTOs;
using GSCMaster.Core.IRepositories;
using GSCMaster.Core.Queries.Moves;
using MediatR;

namespace GSCMaster.Core.QueryHandlers.Moves;
public class GetAllMovesHandler : IRequestHandler<GetAllMovesQuery, IReadOnlyCollection<BasicMoveDTO>>
{
    private readonly IMoveRepository _moveRepository;

    public GetAllMovesHandler(IMoveRepository moveRepository)
    {
        _moveRepository = moveRepository;
    }

    public async Task<IReadOnlyCollection<BasicMoveDTO>> Handle(GetAllMovesQuery request, CancellationToken cancellationToken)
        => await _moveRepository.GetAll(cancellationToken);
}