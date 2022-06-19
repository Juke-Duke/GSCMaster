using GSCMasterGuide.Domain.DTOs;
using MediatR;

namespace GSCMasterGuide.API.Queries.Moves
{
    public class GetMoveQuery : IRequest<FullMoveDTO?>
    {
        public string Name { get; set; } = null!;

        public GetMoveQuery(string name)
            => Name = name;
    }
}