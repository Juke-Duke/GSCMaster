using GSCMaster.Application.Repositories;
using GSCMaster.Core.Entities;
using MediatR;

namespace GSCMaster.Application.CQRS.Moves.Queries;
public sealed record GetAllMovesQuery : IRequest<IReadOnlyCollection<Move>>;

public sealed class GetAllMovesQueryHandler : IRequestHandler<GetAllMovesQuery, IReadOnlyCollection<Move>>
{
    private readonly IMoveRepository _moveRepository;

    public GetAllMovesQueryHandler(IMoveRepository moveRepository)
        => _moveRepository = moveRepository;

    public async Task<IReadOnlyCollection<Move>> Handle(GetAllMovesQuery request, CancellationToken cancellationToken)
        => await _moveRepository.GetAllMovesAsync(cancellationToken);
}

