using GSCMaster.Application.Services.Repositories;
using GSCMaster.Core.MoveAggregate;
using MediatR;

namespace GSCMaster.Application.Features.Resources.MoveDex;
public sealed record GetAllMovesQuery : IRequest<IReadOnlyCollection<Move>>;

public sealed class GetAllMovesQueryHandler : IRequestHandler<GetAllMovesQuery, IReadOnlyCollection<Move>>
{
    private readonly IMoveRepository _moveRepository;

    public GetAllMovesQueryHandler(IMoveRepository moveRepository)
        => _moveRepository = moveRepository;

    public async Task<IReadOnlyCollection<Move>> Handle(GetAllMovesQuery request, CancellationToken cancellationToken)
        => await _moveRepository.GetAllMovesAsync(cancellationToken);
}

