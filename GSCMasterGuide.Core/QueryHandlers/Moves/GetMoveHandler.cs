using GSCMasterGuide.Core.DTOs;
using GSCMasterGuide.Core.IRepositories;
using GSCMasterGuide.Core.Queries.Moves;
using MediatR;

namespace GSCMasterGuide.Core.QueryHandlers.Moves;
public class GetMoveHandler : IRequestHandler<GetMoveQuery, FullMoveDTO?>
{
    private readonly IMoveRepository _moveRepository;

    public GetMoveHandler(IMoveRepository moveRepository)
        => _moveRepository = moveRepository;

    public async Task<FullMoveDTO?> Handle(GetMoveQuery request, CancellationToken cancellationToken)
        => await _moveRepository.Get(request.Name, cancellationToken);
}