using GSCMasterGuide.API.Queries.Moves;
using GSCMasterGuide.Domain.DTOs;
using GSCMasterGuide.Domain.IRepositories;
using MediatR;

namespace GSCMasterGuide.API.QueryHandlers.Moves
{
    public class GetMoveHandler : IRequestHandler<GetMoveQuery, FullMoveDTO?>
    {
        private readonly IMoveRepository _moveRepository;

        public GetMoveHandler(IMoveRepository moveRepository)
            => _moveRepository = moveRepository;

        public async Task<FullMoveDTO?> Handle(GetMoveQuery request, CancellationToken cancellationToken)
            => await _moveRepository.Get(request.Name, cancellationToken);
    }
}
