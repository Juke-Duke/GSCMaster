using GSCMasterGuide.Core.DTOs;
using GSCMasterGuide.Core.IRepositories;
using GSCMasterGuide.Core.Queries.Moves;
using MediatR;

namespace GSCMasterGuide.Core.QueryHandlers.Moves;
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