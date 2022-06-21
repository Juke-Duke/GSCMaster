using GSCMasterGuide.Infrastructure.Queries.Moves;
using GSCMasterGuide.Domain.DTOs;
using GSCMasterGuide.Domain.IRepositories;
using MediatR;

namespace GSCMasterGuide.Infrastructure.QueryHandlers.Moves
{
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
}
