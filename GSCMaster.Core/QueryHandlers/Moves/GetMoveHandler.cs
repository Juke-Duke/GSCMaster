using GSCMaster.Core.DTOs;
using GSCMaster.Core.IRepositories;
using GSCMaster.Core.Queries.Moves;
using MediatR;

namespace GSCMaster.Core.QueryHandlers.Moves;
public class GetMoveHandler : IRequestHandler<GetMoveQuery, FullMoveDTO?>
{
    private readonly IMoveRepository _moveRepository;

    public GetMoveHandler(IMoveRepository moveRepository)
        => _moveRepository = moveRepository;

    public async Task<FullMoveDTO?> Handle(GetMoveQuery request, CancellationToken cancellationToken)
        => await _moveRepository.Get(request.Name, cancellationToken);
}